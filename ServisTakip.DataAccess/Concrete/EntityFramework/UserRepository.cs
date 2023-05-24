using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Extensions;
using ServisTakip.Entities.Enums;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class UserRepository : EntityRepositoryBase<User, ProjectDbContext>, IUserRepository
    {
        public UserRepository(ProjectDbContext context)
            : base(context)
        {
        }

        public List<OperationClaim> GetClaims(long userId)
        {
            var result = (from user in Context.Users
                          join userGroup in Context.UserGroups on user.Id equals userGroup.UserId
                          join groupClaim in Context.GroupClaims on userGroup.GroupId equals groupClaim.GroupId
                          join operationClaim in Context.OperationClaims on groupClaim.OperationClaimId equals operationClaim.Id
                          where user.Id == userId
                          select new
                          {
                              operationClaim.Name
                          });

            return result.Select(x => new OperationClaim { Name = x.Name }).Distinct()
                .ToList();
        }

        public async Task<User> GetByRefreshToken(string refreshToken)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.Status);
        }

        public async Task<List<User>> GetTechnicianUserListAsync(CancellationToken cancellationToken)
        {
            return await Context.Users
                .Include(s=>s.UserGroups)
                .Where(s=>s.CompanyId == Utils.CompanyId && s.UserGroups.Any(t=>t.GroupId == (long)GroupCodes.Technician))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<User>> GetUserListAsync(CancellationToken cancellationToken)
        {
            return await Context.Users
                .Include(s => s.UserGroups).ThenInclude(s=>s.Group)
                .Where(s => s.CompanyId == Utils.CompanyId)
                .ToListAsync(cancellationToken);
        }
    }
}
