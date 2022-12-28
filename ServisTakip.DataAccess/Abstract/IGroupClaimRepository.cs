using ServisTakip.Core.DataAccess;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IGroupClaimRepository : IEntityRepository<GroupClaim>
    {
        Task BulkInsert(long groupId, IEnumerable<GroupClaim> groupClaims);
    }
}
