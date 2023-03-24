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
                .Include(s => s.Address).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => s.RecordUsername == Utils.Email && s.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .OrderByDescending(s => s.RecordDate)
                .FirstOrDefaultAsync();
        }

        public async Task<Device> GetDeviceInfo(long deviceId)
        {
            return await _context.Devices
                .Include(s=>s.DeviceServices).ThenInclude(s=>s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Include(s=>s.Contracts)
                .Where(s => s.Id == deviceId && s.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Device> GetDeviceBySeriNo(string serialNumber)
        {
            return await _context.Devices
                .Include(s => s.DeviceServices).ThenInclude(s => s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Include(s => s.Contracts)
                .Where(s => s.SerialNumber == serialNumber && s.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Device>> GetAllDevices(long customerId)
        {
            return await _context.Devices
                .Include(s => s.Address).ThenInclude(s => s.Customer)
                .Include(s=>s.DeviceModel).ThenInclude(s=>s.DeviceBrand)
                .Where(s => s.Address.CustomerId == customerId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Device>> GetDeviceByFilterAsync(long deviceId, CancellationToken cancellationToken)
        {
            return await _context.Devices
                .Include(s => s.DeviceServices).ThenInclude(s => s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => s.Id == deviceId && s.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Device>> GetDeviceBySerialNoFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _context.Devices
                .Include(s => s.DeviceServices).ThenInclude(s => s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => EF.Functions.Like(s.SerialNumber, $"%{filter}%") && s.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Device>> GetDeviceByModelNameFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _context.Devices
                .Include(s => s.DeviceServices).ThenInclude(s => s.User)
                .Include(s => s.Address).ThenInclude(s => s.Customer).ThenInclude(s => s.Sector)
                .Include(s => s.Address).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Where(s => EF.Functions.Like(s.DeviceModel.Name, $"%{filter}%") && s.Address.Customer.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
