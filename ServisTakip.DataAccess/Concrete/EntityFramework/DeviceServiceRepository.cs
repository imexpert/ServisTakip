using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceServiceRepository : EntityRepositoryBase<DeviceService, ProjectDbContext>, IDeviceServiceRepository
    {
        public DeviceServiceRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
