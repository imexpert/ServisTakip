using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class ContractMaintenanceRepository : EntityRepositoryBase<ContractMaintenance, ProjectDbContext>, IContractMaintenanceRepository
    {
        public ContractMaintenanceRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
