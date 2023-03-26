using Microsoft.EntityFrameworkCore;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class UserGroupRepository : EntityRepositoryBase<UserGroup, ProjectDbContext>, IUserGroupRepository
    {
        public UserGroupRepository(ProjectDbContext context)
            : base(context)
        {
        }

        public async Task BulkInsert(long userId, IEnumerable<UserGroup> userGroups)
        {
            var DbUserGroupList = Context.UserGroups.Where(x => x.UserId == userId);

            Context.UserGroups.RemoveRange(DbUserGroupList);
            await Context.UserGroups.AddRangeAsync(userGroups);
        }

        public async Task BulkInsertByGroupId(long groupId, IEnumerable<UserGroup> userGroups)
        {
            var DbUserGroupList = Context.UserGroups.Where(x => x.GroupId == groupId);

            Context.UserGroups.RemoveRange(DbUserGroupList);
            await Context.UserGroups.AddRangeAsync(userGroups);
        }

        public async Task<List<UserGroup>> GetUserGroupsByUserId(long userId, CancellationToken cancellationToken)
        {
            return await Context.UserGroups
                .Include(s => s.User)
                .Include(s => s.Group)
                .Where(s => s.UserId == userId)
                .ToListAsync(cancellationToken);
        }
    }
}
