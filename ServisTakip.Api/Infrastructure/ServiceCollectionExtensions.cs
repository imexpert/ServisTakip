using System.ComponentModel.DataAnnotations;
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
                        builder.WithOrigins("http://159.69.188.101:6002")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services.AddSwaggerGen();

            services.AddTransient<MsSqlLogger>();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            Func<IServiceProvider, ClaimsPrincipal> getPrincipal = (sp) =>
                sp.GetService<IHttpContextAccessor>().HttpContext?.User ??
                new ClaimsPrincipal(new ClaimsIdentity(""));

            services.AddScoped<IPrincipal>(getPrincipal);

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

        public static void AddCarbonDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext, MsDbContext>();
        }
    }
}
