using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.Extensions;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceServiceRepository : EntityRepositoryBase<DeviceService, ProjectDbContext>, IDeviceServiceRepository
    {
        ProjectDbContext _context;
        public DeviceServiceRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<DeviceService> GetLastTradedCustomerInfo()
        {
            return await _context.DeviceServices
                .Include(s => s.User)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                .Where(s => s.RecordUsername == Utils.Email)
                .OrderByDescending(s=>s.RecordDate)
                .FirstOrDefaultAsync();
        }
    }
}
