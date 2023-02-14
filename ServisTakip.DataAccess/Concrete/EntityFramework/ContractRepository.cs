using Microsoft.EntityFrameworkCore;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class ContractRepository : EntityRepositoryBase<Contract, ProjectDbContext>, IContractRepository
    {
        private readonly ProjectDbContext _context;
        public ContractRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Contract>> GetContractList(long deviceId)
        {
            return await _context.Contracts
                .Include(s => s.Device)
                .Where(s => s.DeviceId == deviceId)
                .ToListAsync();
        }
    }
}
