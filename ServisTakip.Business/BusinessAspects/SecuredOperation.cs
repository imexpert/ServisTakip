using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICacheManager _cacheManager;


        public SecuredOperation()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var operationName = invocation.TargetType.ReflectedType.Name;

            var userId = _httpContextAccessor.HttpContext?.User.Claims
                .FirstOrDefault(x => x.Type == "UserId")?.Value;

            if (userId == null)
            {
                throw new SecurityException(null);
            }

            var oprClaims = _cacheManager.Get($"{CacheKeys.UserIdForClaim}={userId}") as string;

            if (oprClaims == null)
            {
                IUserRepository userRepository = ServiceTool.ServiceProvider.GetService<IUserRepository>();

                var claims = userRepository.GetClaims(Convert.ToInt64(userId));

                _cacheManager.Add($"{CacheKeys.UserIdForClaim}={userId}", claims.Select(x => x.Name), 3600);
            }

            oprClaims = _cacheManager.Get($"{CacheKeys.UserIdForClaim}={userId}") as string;

            if (oprClaims.Contains(operationName))
            {
                return;
            }

            throw new SecurityException($"Bu işlemi yapmaya yetkiniz yok. İşlem Adı : {operationName}");
        }
    }
}
