using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceServiceRepository : IEntityRepository<DeviceService>
    {
        Task<DeviceService> GetLastTradedCustomerInfo();
    }
}
