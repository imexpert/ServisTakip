using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class OperationClaimRepository : EntityRepositoryBase<OperationClaim, ProjectDbContext>,
        IOperationClaimRepository
    {
        public OperationClaimRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
