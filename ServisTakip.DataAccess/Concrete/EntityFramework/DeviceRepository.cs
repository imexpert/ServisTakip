using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.Extensions;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceRepository : EntityRepositoryBase<Device, ProjectDbContext>, IDeviceRepository
    {
        ProjectDbContext _context;
        public DeviceRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Device> GetLastTradedCustomerInfo()
        {
            return await _context.Devices
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.Querter).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => s.RecordUsername == Utils.Email)
                .OrderByDescending(s => s.RecordDate)
                .FirstOrDefaultAsync();
        }

        public async Task<Device> GetDeviceInfo(long deviceId)
        {
            return await _context.Devices
                .Include(s=>s.DeviceServices).ThenInclude(s=>s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.Querter).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => s.Id == deviceId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Device>> GetDeviceByFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _context.Devices
                .Include(s => s.DeviceServices).ThenInclude(s => s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.Querter).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => EF.Functions.Like(s.Id.ToString(), $"%{filter}%"))
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
