using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IContractRepository : IEntityRepository<Contract>
    {
        Task<List<Contract>> GetContractList(long deviceId);
    }
}
