using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServisTakip.Core.Utilities.Security.Encyption;
using ServisTakip.Core.Utilities.Security.Jwt;
using System.Reflection;
using ServisTakip.Business.DependencyResolvers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.CrossCuttingConcerns.Caching.Redis;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using ServisTakip.Core.DependencyResolvers;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json.Serialization;
using ServisTakip.Core.Utilities.Settings;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using ServisTakip.Core.Http;

namespace ServisTakip.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.ForwardLimit = 2;
                options.KnownProxies.Add(IPAddress.Parse("127.0.10.1"));
                options.ForwardedForHeaderName = "X-Forwarded-For-Custom-Header-Name";
            });

            services.AddResponseCompression();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDataProtection();

            services.AddSession();

            services.AddCustomMvc();

            services.AddCustomAuthentication(configuration);
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static void AddCustomMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            //use cookie-based temp data provider
            mvcBuilder.AddCookieTempDataProvider(options =>
            {
                options.Cookie.Name = $"{CustomCookieDefaults.Prefix}{CustomCookieDefaults.TempDataCookie}";
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            });

            services.AddRazorPages();

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //set some options
            mvcBuilder.AddMvcOptions(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddRazorRuntimeCompilation();

            services.AddMvc(s =>
            {
                s.EnableEndpointRouting = false;
            });

            //register controllers as services, it'll allow to override them
            mvcBuilder.AddControllersAsServices();
        }

        /// <summary>
        /// Adds services required for anti-forgery support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddAntiForgery(this IServiceCollection services)
        {
            //override cookie name
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = $"{CustomCookieDefaults.Prefix}{CustomCookieDefaults.AntiforgeryCookie}";
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            });
        }

        /// <summary>
        /// Adds services required for anti-forgery support
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
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
    }
}
