using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json.Serialization;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServisTakip.Business.DependencyResolvers;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.CrossCuttingConcerns.Caching.Redis;
using ServisTakip.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using ServisTakip.Core.DependencyResolvers;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Security.Encyption;
using ServisTakip.Core.Utilities.Security.Jwt;
using ServisTakip.Core.Utilities.Settings;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using StackExchange.Redis;

namespace ServisTakip.Api.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddTransient<ITokenHelper, JwtHelper>();
        }

        public static void AddCustomMediatR(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(AutofacBusinessModule));

            services.AddMediatR(assembly);
        }

        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));

            Assembly assembly = Assembly.GetAssembly(typeof(AutofacBusinessModule));

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder =>
                        builder.WithOrigins("http://localhost:8080", "http://192.168.68.111:8080", "https://www.avrpro.net", "http://www.avrpro.net", "http://avrpro.net", "https://avrpro.net", "http://192.168.1.166:8080")
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyHeader());
            });

            services.AddSwaggerGen();

            services.AddTransient<MsSqlLogger>();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            Func<IServiceProvider, ClaimsPrincipal> getPrincipal = (sp) =>
                sp.GetService<IHttpContextAccessor>().HttpContext?.User ??
                new ClaimsPrincipal(new ClaimsIdentity(""));

            services.AddScoped<IPrincipal>(getPrincipal);

            var _redis = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { $"{configuration.GetValue<string>("RedisSettings:Host")}:{configuration.GetValue<string>("RedisSettings:Port")}" }
            });

            services.AddSingleton<IConnectionMultiplexer>(_redis);

            var coreModule = new CoreModule();

            services.AddDependencyResolvers(configuration, new ICoreModule[] { coreModule });

            services.AddAutoMapper(assembly);

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            {
                return memberInfo.GetCustomAttribute<DisplayAttribute>()
                    ?.GetName();
            };
        }

        public static void AddCustomCacheServices(this IServiceCollection services)
        {
            services.AddSingleton<ICacheManager, RedisCacheManager>();
        }

        public static void AddServisTakipDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext, MsDbContext>();
        }
    }
}
