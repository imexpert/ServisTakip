using ServisTakip.Core.DataAccess;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(long userId);
        Task<User> GetByRefreshToken(string refreshToken);
        Task<List<User>> GetTechnicianUserListAsync(CancellationToken cancellationToken);
        Task<List<User>> GetUserListAsync(CancellationToken cancellationToken);
    }
}
