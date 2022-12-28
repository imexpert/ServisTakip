using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DistrictRepository : EntityRepositoryBase<District, ProjectDbContext>, IDistrictRepository
    {
        public DistrictRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
