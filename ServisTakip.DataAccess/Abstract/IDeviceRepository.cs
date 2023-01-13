using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceRepository : IEntityRepository<Device>
    {
        Task<Device> GetLastTradedCustomerInfo();
    }
}
