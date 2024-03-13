using ServisTakip.Core.ApiDoc;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.CrossCuttingConcerns.Caching.Redis;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ServisTakip.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace ServisTakip.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerMessages.Version, new OpenApiInfo
                {
                    Version = SwaggerMessages.Version,
                    Title = SwaggerMessages.Title,
                    Description = SwaggerMessages.Description
                    // TermsOfService = new Uri(SwaggerMessages.TermsOfService),
                    // Contact = new OpenApiContact
                    // {
                    //    Name = SwaggerMessages.ContactName,
                    // },
                    // License = new OpenApiLicense
                    // {
                    //    Name = SwaggerMessages.LicenceName,
                    // },
                });

                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "`Token only!!!` - without `Bearer_` prefix",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
            });
        }
    }
}
