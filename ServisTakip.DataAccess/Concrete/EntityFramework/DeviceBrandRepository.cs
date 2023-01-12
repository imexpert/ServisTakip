using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceBrandRepository : EntityRepositoryBase<DeviceBrand, ProjectDbContext>, IDeviceBrandRepository
    {
        public DeviceBrandRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
