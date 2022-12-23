using ServisTakip.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string Username
        {
            get
            {
                var context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    return context.HttpContext.User.Claims.First(s => s.Type == "UserCode").Value;
                }

                return "-";
            }
            private set { }
        }

        public static string ClientIp
        {
            get
            {
                return "0.0.0.0";
            }
            private set { }
        }
    }
}
