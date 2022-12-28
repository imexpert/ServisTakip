using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FluentValidation;
using MediatR;
using ServisTakip.Core.Utilities.Interceptors;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;

namespace ServisTakip.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Autofac.Module
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(MsDbContext));

            builder.RegisterAssemblyTypes(repoAssembly)
                .Where(s => s.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .AsClosedTypesOf(typeof(IValidator<>));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .Where(t => t.FullName.StartsWith("ServisTakip.Business"));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .Where(t => t.FullName.StartsWith("ServisTakip.DataAccess"));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance().InstancePerDependency();
        }
    }
}
