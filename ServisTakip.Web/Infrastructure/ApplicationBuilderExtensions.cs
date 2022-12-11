using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;
using ServisTakip.Core.Utilities.IoC;
using System.Net;
using ServisTakip.Web.Helpers;

namespace ServisTakip.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="httpContextAccessor"></param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application, IHttpContextAccessor httpContextAccessor)
        {
            HttpClientExtensions.SetContext(httpContextAccessor);

            // VERY IMPORTANT. Since we removed the build from AddDependencyResolvers, let's set the Service provider manually.
            // By the way, we can construct with DI by taking type to avoid calling static methods in aspects.
            ServiceTool.ServiceProvider = application.ApplicationServices;

            //get detailed exceptions for developing and testing purposes
            application.UseDeveloperExceptionPage();

            application.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("/Login");
                return Task.CompletedTask;
            });

            application.UseCustomResponseCompression();

            application.UseCustomStaticFiles();

            application.UsePageNotFound(httpContextAccessor);

            application.UseCustomExceptionHandler();

            application.UseBadRequestResult();

            application.UseSession();

            application.UseRouting();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
            };

            application.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 401)
                {
                    context.Request.Path = "/Login/Index";
                    await next();
                }
            });

            application.UseCookiePolicy(cookiePolicyOptions);

            application.UseAuthentication();

            application.UseAuthorization();

            application.UseEndpoints(s => s.MapControllers());

            application.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area}/{controller}/{action}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Presentation}/{action=Index}");
            });
        }

        /// <summary>
        /// Configure middleware for dynamically compressing HTTP responses
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseCustomResponseCompression(this IApplicationBuilder application)
        {
            application.UseResponseCompression();
        }

        /// <summary>
        /// Configure static file serving
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseCustomStaticFiles(this IApplicationBuilder application)
        {
            void staticFileResponse(StaticFileResponseContext context)
            {
                context.Context.Response.Headers.Append(HeaderNames.CacheControl, "public,max-age=31536000");
            }

            //common static files
            application.UseStaticFiles(new StaticFileOptions { OnPrepareResponse = staticFileResponse });
        }

        /// <summary>
        /// Adds a special handler that checks for responses with the 404 status code that do not have a body
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UsePageNotFound(this IApplicationBuilder application, IHttpContextAccessor httpContextAccessor)
        {
            application.UseStatusCodePages(context =>
            {
                //handle 404 Not Found
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    if (!IsStaticResource(httpContextAccessor))
                    {
                        //get original path and query
                        var originalPath = context.HttpContext.Request.Path;
                        var originalQueryString = context.HttpContext.Request.QueryString;

                        //var logger = EngineContext.Current.Resolve<ILogger>();
                        //var workContext = EngineContext.Current.Resolve<IWorkContext>();

                        //await logger.ErrorAsync($"Error 404. The requested page ({originalPath}) was not found",
                        //    customer: await workContext.GetCurrentCustomerAsync());

                        try
                        {
                            context.HttpContext.Response.Redirect("/Home/SayfaBulunamadi?path=" + originalPath);
                        }
                        finally
                        {
                            //return original path to request
                            context.HttpContext.Request.QueryString = originalQueryString;
                            context.HttpContext.Request.Path = originalPath;
                        }
                    }
                }

                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Add exception handling
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseCustomExceptionHandler(this IApplicationBuilder application)
        {
            //log errors
            application.UseExceptionHandler(handler =>
            {
                handler.Run(context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception == null)
                        return Task.CompletedTask;
                    try
                    {
                        if (exception.GetType() == typeof(UnAuthorizeException))
                        {
                            foreach (var cookie in context.Request.Cookies.Keys)
                            {
                                context.Response.Cookies.Delete(cookie);
                            }

                            context.Response.StatusCode = 401;
                            context.Response.Redirect(context.Request.PathBase + "/Login/Index");
                        }
                        else
                        {
                            context.Response.Redirect(context.Request.PathBase + "/Home/Error");
                        }
                    }
                    finally
                    {
                        //rethrow the exception to show the error page
                        //ExceptionDispatchInfo.Throw(exception);
                    }

                    return Task.CompletedTask;
                });
            });
        }

        /// <summary>
        /// Adds a special handler that checks for responses with the 400 status code (bad request)
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseBadRequestResult(this IApplicationBuilder application)
        {
            application.UseStatusCodePages(context =>
            {
                //handle 404 (Bad request)
                if (context.HttpContext.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    //await logger.ErrorAsync("Error 400. Bad request", null, customer: "");
                }

                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Check whether current HTTP request is available
        /// </summary>
        /// <returns>True if available; otherwise false</returns>
        private static bool IsRequestAvailable(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor?.HttpContext == null)
                return false;

            try
            {
                if (httpContextAccessor.HttpContext.Request == null)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool IsStaticResource(IHttpContextAccessor httpContextAccessor)
        {
            if (!IsRequestAvailable(httpContextAccessor))
                return false;

            string path = httpContextAccessor.HttpContext.Request.Path;

            //a little workaround. FileExtensionContentTypeProvider contains most of static file extensions. So we can use it
            //source: https://github.com/aspnet/StaticFiles/blob/dev/src/Microsoft.AspNetCore.StaticFiles/FileExtensionContentTypeProvider.cs
            //if it can return content type, then it's a static file
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            return contentTypeProvider.TryGetContentType(path, out var _);
        }
    }
}
