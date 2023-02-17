using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.Extensions;
using ServisTakip.Entities.DTOs.Reports;

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
                .Include(s=>s.Device)
                    .ThenInclude(s=>s.DeviceModel)
                    .ThenInclude(s=>s.DeviceBrand)
                    .ThenInclude(s=>s.DeviceType)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s=>s.Sector)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s=>s.Querter)
                    .ThenInclude(s=>s.District)
                    .ThenInclude(s=>s.City)
                .Where(s => s.RecordUsername == Utils.Email)
                .AsNoTracking()
                .OrderByDescending(s=>s.RecordDate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<DeviceService>> GetDeviceServices(long deviceId)
        {
            return await _context.DeviceServices
                .Include(s => s.User)
                .Include(s => s.Device)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s => s.Sector)
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Querter)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                .Where(s => s.DeviceId == deviceId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .ToListAsync();
        }

        public async Task<List<DeviceService>> GetDeviceServiceWithStatusCode(int statusCode)
        {
            return await _context.DeviceServices
                .Include(s => s.User)
                .Include(s => s.Device)
                .ThenInclude(s => s.DeviceModel)
                .ThenInclude(s => s.DeviceBrand)
                .ThenInclude(s => s.DeviceType)
                .Include(s => s.Device)
                .ThenInclude(s => s.Address)
                .ThenInclude(s => s.Customer)
                .ThenInclude(s => s.Sector)
                .Include(s => s.Device)
                .ThenInclude(s => s.Address)
                .ThenInclude(s => s.Querter)
                .ThenInclude(s => s.District)
                .ThenInclude(s => s.City)
                .Where(s => s.StatusCode == statusCode && s.Device.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .ToListAsync();
        }

        public async Task<List<TechnicianDeviceServiceReportModel>> GetTechnicianDeviceServiceListAsync(long userId, CancellationToken cancellationToken)
        {
            return await _context.TechnicianDeviceServiceReports
                .Where(s => s.UserId == userId)
                .ToListAsync(cancellationToken);
        }
    }
}
