using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceRepository : EntityRepositoryBase<Device, ProjectDbContext>, IDeviceRepository
    {
        public DeviceRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
