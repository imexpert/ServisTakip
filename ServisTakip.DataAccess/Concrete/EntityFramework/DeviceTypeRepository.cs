using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceTypeRepository : EntityRepositoryBase<DeviceType, ProjectDbContext>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
