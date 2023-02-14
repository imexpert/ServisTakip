using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceServiceRepository : IEntityRepository<DeviceService>
    {
        Task<DeviceService> GetLastTradedCustomerInfo();
        Task<List<DeviceService>> GetDeviceServices(long deviceId);
        Task<List<DeviceService>> GetDeviceServiceWithStatusCode(int statusCode);
    }
}
