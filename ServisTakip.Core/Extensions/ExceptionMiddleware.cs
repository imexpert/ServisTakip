using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace ServisTakip.Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }


        private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            ResponseMessage<NoContent> result = new()
            {
                IsSuccess = false
            };

            var environment = ServiceTool.ServiceProvider.GetService<IWebHostEnvironment>();

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            if (environment.IsDevelopment() || environment.IsStaging())
            {
                result.Message = e.GetInnermostException().Message;
            }
            else
            {
                result.Message = "İşlem sırasında hata oluştu. Lütfen tekrar deneyiniz.";
            }

            DefaultContractResolver contractResolver = new()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            await httpContext.Response.WriteAsync(json);
        }
    }
}
