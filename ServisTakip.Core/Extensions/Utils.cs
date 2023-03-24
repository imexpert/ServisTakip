using ServisTakip.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ServisTakip.Core.Extensions
{
    public static class Utils
    {
        public static long UserId 
        {
            get 
            {
                var context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    return Convert.ToInt64(context.HttpContext.User.Claims.First(s => s.Type == "UserId").Value);
                }

                return 0;
            }
            private set { } 
        }

        public static long CompanyId
        {
            get
            {
                var context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    return Convert.ToInt64(context.HttpContext.User.Claims.First(s => s.Type == "CompanyId").Value);
                }

                return 0;
            }
            private set { }
        }

        public static string Email
        {
            get
            {
                var context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    return context.HttpContext.User.Claims.First(s => s.Type == "Email").Value;
                }

                return "-";
            }
            private set { }
        }

        public static string ClientIp
        {
            get
            {
                var context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
                return context.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            private set { }
        }
    }
}
