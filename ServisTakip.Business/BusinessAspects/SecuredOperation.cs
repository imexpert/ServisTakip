using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Security;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.Utilities.Interceptors;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.DataAccess.Abstract;

namespace ServisTakip.Business.BusinessAspects
{
    /// <summary>
    /// This Aspect control the user's roles in HttpContext by inject the IHttpContextAccessor.
    /// It is checked by writing as [SecuredOperation] on the handler.
    /// If a valid authorization cannot be found in aspect, it throws an exception.
    /// </summary>
    public class SecuredOperation : MethodInterception
    {

        protected override void OnBefore(IInvocation invocation)
        {
            var operationName = invocation.TargetType.ReflectedType.Name;

            var userId = Tools.HttpContextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(x => x.Type == "UserId")?.Value;

            if (userId == null)
            {
                throw new SecurityException(null);
            }

            var oprClaims = Tools.CacheManager.Get($"{CacheKeys.UserIdForClaim}={userId}") as string;

            if (oprClaims == null)
            {
                IUserRepository userRepository = ServiceTool.ServiceProvider.GetService<IUserRepository>();

                var claims = userRepository.GetClaims(Convert.ToInt64(userId));

                Tools.CacheManager.Add($"{CacheKeys.UserIdForClaim}={userId}", claims.Select(x => x.Name), 3600);
            }

            oprClaims = Tools.CacheManager.Get($"{CacheKeys.UserIdForClaim}={userId}") as string;

            if (oprClaims.Contains(operationName))
            {
                return;
            }

            throw new SecurityException($"Bu işlemi yapmaya yetkiniz yok. İşlem Adı : {operationName}");
        }
    }
}
