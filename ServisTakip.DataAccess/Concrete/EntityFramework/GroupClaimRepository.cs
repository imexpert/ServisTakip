using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class GroupClaimRepository : EntityRepositoryBase<GroupClaim, ProjectDbContext>, IGroupClaimRepository
    {
        public GroupClaimRepository(ProjectDbContext context)
            : base(context)
        {
        }

        public async Task BulkInsert(long groupId, IEnumerable<GroupClaim> groupClaims)
        {
            var DbList = await Context.GroupClaims.Where(x => x.GroupId == groupId).ToListAsync();
            Context.GroupClaims.RemoveRange(DbList);
            await Context.GroupClaims.AddRangeAsync(groupClaims);
        }
    }
}
