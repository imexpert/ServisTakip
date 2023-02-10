using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceRepository : IEntityRepository<Device>
    {
        Task<Device> GetLastTradedCustomerInfo();
        Task<Device> GetDeviceInfo(long deviceId);
        Task<List<Device>> GetDeviceByFilterAsync(long deviceId, CancellationToken cancellationToken);
        Task<List<Device>> GetDeviceBySerialNoFilterAsync(string filter, CancellationToken cancellationToken);
        Task<List<Device>> GetDeviceByModelNameFilterAsync(string filter, CancellationToken cancellationToken);
    }
}
