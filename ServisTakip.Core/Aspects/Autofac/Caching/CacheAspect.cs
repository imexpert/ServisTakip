using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.Utilities.Interceptors;
using ServisTakip.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Core.Aspects.Autofac.Caching
{
    /// <summary>
    /// CacheAspect
    /// </summary>
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Arguments[0]}.{invocation.Method.Name}");
            var arguments = invocation.Arguments;
            var key = $"{methodName}({BuildKey(arguments)})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }


        string BuildKey(object[] args)
        {
            var sb = new StringBuilder();
            foreach (var arg in args)
            {
                var paramValues = arg.GetType().GetProperties()
                    .Select(p => p.GetValue(arg)?.ToString() ?? string.Empty);
                sb.Append(string.Join('_', paramValues));
            }

            return sb.ToString();
        }
    }
}
