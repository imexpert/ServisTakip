using ServisTakip.Core.DataAccess;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IUserGroupRepository : IEntityRepository<UserGroup>
    {
        Task BulkInsert(long userId, IEnumerable<UserGroup> userGroups);
        Task BulkInsertByGroupId(long groupId, IEnumerable<UserGroup> userGroups);
    }
}
