using Microsoft.EntityFrameworkCore;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

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

        public async Task<List<Contract>> GetSozlesmeBasimListAsync(SozlesmeBasimRaporFilter filter, CancellationToken cancellationToken)
        {
            return await _context.Contracts
                .Include(s => s.Device)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Querter)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                .Where(s => s.Device.Status)
                .ToListAsync(cancellationToken);
        }
    }
}
