using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.Utilities.Interceptors;
using ServisTakip.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServisTakip.Core.Aspects.Autofac.Transaction
{
    /// <summary>
    /// TransactionScopeAspect
    /// </summary>
    public class TransactionScopeAspectAsync : MethodInterception
    {

        public static void InterceptDbContext(IInvocation invocation)
        {
            var db = ServiceTool.ServiceProvider.GetService(default) as DbContext;
            using var transactionScope = db.Database.BeginTransaction();
            try
            {
                invocation.Proceed();
                transactionScope.Commit();
            }
            finally
            {
                transactionScope.Rollback();
            }
        }

        public override void Intercept(IInvocation invocation)
        {
            using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            invocation.Proceed();
            tx.Complete();
        }
    }
}
