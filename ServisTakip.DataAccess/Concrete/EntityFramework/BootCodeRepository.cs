using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class BootCodeRepository : EntityRepositoryBase<BootCode, ProjectDbContext>, IBootCodeRepository
    {
        public BootCodeRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
