using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IContractRepository : IEntityRepository<Contract>
    {
        Task<List<Contract>> GetContractList(long deviceId);
        Task<List<Contract>> GetSozlesmeBasimListAsync(SozlesmeBasimRaporFilter filter, CancellationToken cancellationToken);
    }
}
