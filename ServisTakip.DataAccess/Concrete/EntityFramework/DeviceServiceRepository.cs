using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.Extensions;
using ServisTakip.Entities.DTOs.Reports;
using ServisTakip.Entities.Enums;

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
                .Include(s => s.User).AsNoTracking()
                .Include(s=>s.Device)
                    .ThenInclude(s=>s.DeviceModel)
                    .ThenInclude(s=>s.DeviceBrand)
                    .ThenInclude(s=>s.DeviceType)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s=>s.Sector)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s=>s.Querter)
                    .ThenInclude(s=>s.District)
                    .ThenInclude(s=>s.City)
                    .AsNoTracking()
                .Where(s => s.RecordUsername == Utils.Email && s.Device.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s=>s.UpdateDate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<DeviceService>> GetDeviceServices(long deviceId)
        {
            return await _context.DeviceServices
                .Include(s => s.User).AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s => s.Sector)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Querter)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                    .AsNoTracking()
                .Where(s => s.DeviceId == deviceId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .ToListAsync();
        }

        public async Task<List<DeviceService>> GetDeviceServiceWithStatusCode(int statusCode)
        {
            return await _context.DeviceServices
                .Include(s => s.User).AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s => s.Sector)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Querter)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                    .AsNoTracking()
                .Where(s => s.StatusCode == statusCode && s.Device.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .ToListAsync();
        }

        public async Task<List<DeviceService>> GetToBeOfferedDeviceServiceWithStatusCode(CancellationToken cancellationToken)
        {
            return await _context.DeviceServices
                .Include(s => s.User).AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s => s.Sector)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Querter)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                    .AsNoTracking()
                .Where(s => (s.StatusCode == ((int)StatusCodes.ParcaDegisimTalebi) || s.StatusCode == ((int)StatusCodes.TeklifGonderilecek)) && s.Device.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<DeviceService>> GetSentOfferedDeviceServiceWithStatusCode(CancellationToken cancellationToken)
        {
            return await _context.DeviceServices
                .Include(s => s.User).AsNoTracking()
                .Include(s => s.Device)
                .ThenInclude(s => s.DeviceModel)
                .ThenInclude(s => s.DeviceBrand)
                .ThenInclude(s => s.DeviceType)
                .AsNoTracking()
                .Include(s => s.Device)
                .ThenInclude(s => s.Address)
                .ThenInclude(s => s.Customer)
                .ThenInclude(s => s.Sector)
                .AsNoTracking()
                .Include(s => s.Device)
                .ThenInclude(s => s.Address)
                .ThenInclude(s => s.Querter)
                .ThenInclude(s => s.District)
                .ThenInclude(s => s.City)
                .AsNoTracking()
                .Where(s => (s.StatusCode == ((int)StatusCodes.TeklifGonderildi) || s.StatusCode == ((int)StatusCodes.TeklifGonderilecek)) && s.Device.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<DeviceService> GetDeviceServiceWithId(long id, CancellationToken cancellationToken)
        {
            return await _context.DeviceServices
                .Include(s => s.User).AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Customer)
                    .ThenInclude(s => s.Sector)
                    .AsNoTracking()
                .Include(s => s.Device)
                    .ThenInclude(s => s.Address)
                    .ThenInclude(s => s.Querter)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                    .AsNoTracking()
                .Where(s => s.Id == id && s.Device.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TechnicianDeviceServiceReportModel>> GetTechnicianDeviceServiceListAsync(long userId, CancellationToken cancellationToken)
        {
            return await _context.TechnicianDeviceServiceReports
                .Where(s => s.UserId == userId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
