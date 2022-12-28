using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class SectorRepository : EntityRepositoryBase<Sector, ProjectDbContext>, ISectorRepository
    {
        public SectorRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
