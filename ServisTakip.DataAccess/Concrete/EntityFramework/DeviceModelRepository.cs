using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceModelRepository : EntityRepositoryBase<DeviceModel, ProjectDbContext>, IDeviceModelRepository
    {
        public DeviceModelRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
