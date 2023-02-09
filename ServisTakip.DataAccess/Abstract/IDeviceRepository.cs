using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceRepository : IEntityRepository<Device>
    {
        Task<Device> GetLastTradedCustomerInfo();
        Task<Device> GetDeviceInfo(long deviceId);
        Task<List<Device>> GetDeviceByFilterAsync(string filter, CancellationToken cancellationToken);
    }
}
