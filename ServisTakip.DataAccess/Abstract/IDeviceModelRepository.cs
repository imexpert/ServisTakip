using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceModelRepository : IEntityRepository<DeviceModel>
    {
        Task<List<DeviceModel>> GetModelByFilterAsync(string filter, CancellationToken cancellationToken);
    }
}
