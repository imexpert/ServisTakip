using ServisTakip.Core.Aspects.Autofac.Exception;
using ServisTakip.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Castle.DynamicProxy;
using System.Reflection;

namespace ServisTakip.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes =
                type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            if (methodAttributes != null)
            {
                classAttributes.AddRange(methodAttributes);
            }

            //Default olarak çalışmasını istediğiniz aspect varsa bu kısma ekleyebilirsiniz.
            classAttributes.Add(new ExceptionLogAspect(typeof(MsSqlLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
