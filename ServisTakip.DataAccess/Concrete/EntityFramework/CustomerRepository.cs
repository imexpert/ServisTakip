using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Extensions;
using ServisTakip.Entities.Concrete;
using Z.EntityFramework.Plus;
using ServisTakip.Entities.DTOs.Reports;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Core.Utilities.Results;
using Azure.Core;
using System.Threading;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class CustomerRepository : EntityRepositoryBase<Customer, ProjectDbContext>, ICustomerRepository
    {
        private readonly ProjectDbContext _context;
        public CustomerRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(long id)
        {
            return await _context.Customers
                .Include(s => s.Addresses).ThenInclude(s => s.Devices).ThenInclude(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Include(s => s.Addresses).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.Sector)
                .Where(s => s.Id == id && s.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetCustomerByFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Include(s => s.Addresses).ThenInclude(s => s.Devices).ThenInclude(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Include(s => s.Addresses).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.Sector)
                .Where(s => EF.Functions.Like(s.Title, $"%{filter}%") && s.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Customer>> GetCustomerListAsync(CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Include(s => s.Addresses).ThenInclude(s => s.Devices).ThenInclude(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Include(s => s.Addresses).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.Sector)
                .Where(s => s.CompanyId == Utils.CompanyId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }

        public IQueryable<Customer> GetMusteriRaporQuery()
        {
            return _context.Customers
                .Include(s => s.Addresses)
                    .ThenInclude(s => s.District)
                    .ThenInclude(s => s.City)
                .Include(s => s.Addresses)
                    .ThenInclude(s => s.Devices)
                    .ThenInclude(s => s.DeviceModel)
                    .ThenInclude(s => s.DeviceBrand)
                    .ThenInclude(s => s.DeviceType)
                .Include(s => s.Addresses)
                    .ThenInclude(s => s.Devices)
                    .ThenInclude(s => s.Contracts);
        }

        public async Task<PagedResult<List<CustomerReportDto>>> GetMusteriRaporQuery(MusteriRaporFilter filter, CancellationToken cancellationToken)
        {
            var pagedResult = new PagedResult<List<CustomerReportDto>>();

            List<CustomerReportDto> list = new List<CustomerReportDto>();

            var query = (from c in Context.Customers
                         join a in Context.Addresses on c.Id equals a.CustomerId into addresses
                         from address in addresses.DefaultIfEmpty()
                         join d in Context.Districts on address.DistrictId equals d.Id into districts
                         from district in districts.DefaultIfEmpty()
                         join city in Context.Cities on district.CityId equals city.Id into cities
                         from city in cities.DefaultIfEmpty()
                         join device in Context.Devices on address.Id equals device.AddressId into devices
                         from device in devices.DefaultIfEmpty()
                         join model in Context.DeviceModels on device.DeviceModelId equals model.Id into models
                         from model in models.DefaultIfEmpty()
                         join brand in Context.DeviceBrands on model.DeviceBrandId equals brand.Id into brands
                         from brand in brands.DefaultIfEmpty()
                         join type in Context.DeviceTypes on brand.DeviceTypeId equals type.Id into types
                         from type in types.DefaultIfEmpty()
                         join ctemp in (from c in Context.Contracts
                                        where c.EndDate == Context.Contracts.Where(c2 => c2.DeviceId == c.DeviceId).Max(c2 => c2.EndDate)
                                        select c) on device.Id equals ctemp.DeviceId into devicesTemp
                         from ctemp in devicesTemp.DefaultIfEmpty()
                         where c.CompanyId == Utils.CompanyId &&
                               (!filter.CustomerId.HasValue || c.Id == filter.CustomerId) &&
                               (!filter.SehirId.HasValue || city.Id == filter.SehirId) &&
                               (!filter.IlceId.HasValue || district.Id == filter.IlceId) &&
                               (!filter.Model.HasValue || model.Id == filter.Model) &&
                               (string.IsNullOrEmpty(filter.SerialNo) || device.SerialNumber.Contains(filter.SerialNo)) &&
                               (filter.SozlesmeKodlari.Count == 0 || filter.SozlesmeKodlari.Any(s => s == ctemp.ContractCode)) &&
                               (!filter.BaslangicTarihi.HasValue || ctemp.StartDate >= filter.BaslangicTarihi) &&
                               (!filter.BitisTarihi.HasValue || ctemp.EndDate <= filter.BitisTarihi)
                         select new
                         {
                             Sehir = city != null ? city.Name : null,
                             Ilce = district != null ? district.Name : null,
                             Semt = address != null ? address.QuerterName : null,
                             AddressId = address != null ? address.Id : (long?)null,
                             Tip = type != null ? type.Name : null,
                             Marka = brand != null ? brand.Name : null,
                             Model = model != null ? model.Name : null,
                             CihazSeriNo = device != null ? device.SerialNumber : null,
                             MontajTarihi = device != null ? device.AssemblyDate : (DateTime?)null,
                             DeviceId = device != null ? device.Id : (long?)null,
                             Unvan = c.Title,
                             CustomerId = c.Id,
                             SozlesmeKodu = ctemp != null ? ctemp.ContractCode : null,
                             BaslangicTarihi = ctemp != null ? ctemp.StartDate.ToString("dd/MM/yyyy") : null,
                             BitisTarihi = ctemp != null ? ctemp.EndDate.ToString("dd/MM/yyyy") : null,
                             AcikAdres = address != null ? address.NetAddress : null,
                             Departman = address != null ? address.Department : null,
                         })
                .AsQueryable();

            pagedResult.PageCount = await query.CountAsync(cancellationToken);

            query = query
                .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize);

            var result = await query.ToListAsync(cancellationToken);

            foreach (var item in result)
            {
                CustomerReportDto customer = new CustomerReportDto()
                {
                    AddressId = item.AddressId,
                    Unvan = item.Unvan,
                    Sehir = item.Sehir,
                    Ilce = item.Ilce,
                    Semt = item.Semt,
                    Tip = item.Tip,
                    Marka = item.Marka,
                    Model = item.Model,
                    MontajTarihi = item.MontajTarihi?.ToString("dd/MM/yyyy"),
                    CihazSeriNo = item.CihazSeriNo,
                    BaslangicTarihi = item.BaslangicTarihi,
                    BitisTarihi = item.BitisTarihi,
                    SozlesmeKodu = item.SozlesmeKodu,
                    AcikAdres = item.AcikAdres,
                    Departman = item.Departman
                };

                list.Add(customer);
            }

            pagedResult.Data = list.OrderBy(s => s.Unvan).ToList();
            pagedResult.PageSize = filter.PageSize;
            pagedResult.CurrentPage = filter.CurrentPage;
            pagedResult.IsSuccess = true;
            return pagedResult;
        }

        public async Task<List<CustomerReportDto>> GetCustomerReportFile(MusteriRaporFilter filter,
            CancellationToken cancellationToken)
        {
            List<CustomerReportDto> list = new List<CustomerReportDto>();

            var query = (from c in Context.Customers
                         join a in Context.Addresses on c.Id equals a.CustomerId into addresses
                         from address in addresses.DefaultIfEmpty()
                         join d in Context.Districts on address.DistrictId equals d.Id into districts
                         from district in districts.DefaultIfEmpty()
                         join city in Context.Cities on district.CityId equals city.Id into cities
                         from city in cities.DefaultIfEmpty()
                         join device in Context.Devices on address.Id equals device.AddressId into devices
                         from device in devices.DefaultIfEmpty()
                         join model in Context.DeviceModels on device.DeviceModelId equals model.Id into models
                         from model in models.DefaultIfEmpty()
                         join brand in Context.DeviceBrands on model.DeviceBrandId equals brand.Id into brands
                         from brand in brands.DefaultIfEmpty()
                         join type in Context.DeviceTypes on brand.DeviceTypeId equals type.Id into types
                         from type in types.DefaultIfEmpty()
                         join ctemp in (from c in Context.Contracts
                                        where c.EndDate == Context.Contracts.Where(c2 => c2.DeviceId == c.DeviceId).Max(c2 => c2.EndDate)
                                        select c) on device.Id equals ctemp.DeviceId into devicesTemp
                         from ctemp in devicesTemp.DefaultIfEmpty()
                         where c.CompanyId == Utils.CompanyId &&
                               (!filter.CustomerId.HasValue || c.Id == filter.CustomerId) &&
                               (!filter.SehirId.HasValue || city.Id == filter.SehirId) &&
                               (!filter.IlceId.HasValue || district.Id == filter.IlceId) &&
                               (!filter.Model.HasValue || model.Id == filter.Model) &&
                               (string.IsNullOrEmpty(filter.SerialNo) || device.SerialNumber.Contains(filter.SerialNo)) &&
                               (filter.SozlesmeKodlari.Count == 0 || filter.SozlesmeKodlari.Any(s => s == ctemp.ContractCode)) &&
                               (!filter.BaslangicTarihi.HasValue || ctemp.StartDate >= filter.BaslangicTarihi) &&
                               (!filter.BitisTarihi.HasValue || ctemp.EndDate <= filter.BitisTarihi)
                         select new
                         {
                             Sehir = city != null ? city.Name : null,
                             Ilce = district != null ? district.Name : null,
                             Semt = address != null ? address.QuerterName : null,
                             AddressId = address != null ? address.Id : (long?)null,
                             Tip = type != null ? type.Name : null,
                             Marka = brand != null ? brand.Name : null,
                             Model = model != null ? model.Name : null,
                             CihazSeriNo = device != null ? device.SerialNumber : null,
                             MontajTarihi = device != null ? device.AssemblyDate : (DateTime?)null,
                             DeviceId = device != null ? device.Id : (long?)null,
                             Unvan = c.Title,
                             CustomerId = c.Id,
                             SozlesmeKodu = ctemp != null ? ctemp.ContractCode : null,
                             BaslangicTarihi = ctemp != null ? ctemp.StartDate.ToString("dd/MM/yyyy") : null,
                             BitisTarihi = ctemp != null ? ctemp.EndDate.ToString("dd/MM/yyyy") : null,

                         })
                .AsQueryable();

            query = query
                .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize);

            var result = await query.ToListAsync(cancellationToken);

            foreach (var item in result)
            {
                CustomerReportDto customer = new CustomerReportDto()
                {
                    AddressId = item.AddressId,
                    Unvan = item.Unvan,
                    Sehir = item.Sehir,
                    Ilce = item.Ilce,
                    Semt = item.Semt,
                    Tip = item.Tip,
                    Marka = item.Marka,
                    Model = item.Model,
                    MontajTarihi = item.MontajTarihi?.ToString("dd/MM/yyyy"),
                    CihazSeriNo = item.CihazSeriNo,
                    BaslangicTarihi = item.BaslangicTarihi,
                    BitisTarihi = item.BitisTarihi,
                    SozlesmeKodu = item.SozlesmeKodu
                };

                list.Add(customer);
            }

            return list;
        }

        public async Task<List<CustomerReportDto>> GetCustomerReportFileWithoutPaging(MusteriRaporFilter filter,
            CancellationToken cancellationToken)
        {
            List<CustomerReportDto> list = new List<CustomerReportDto>();

            var query = (from c in Context.Customers
                         join a in Context.Addresses on c.Id equals a.CustomerId into addresses
                         from address in addresses.DefaultIfEmpty()
                         join d in Context.Districts on address.DistrictId equals d.Id into districts
                         from district in districts.DefaultIfEmpty()
                         join city in Context.Cities on district.CityId equals city.Id into cities
                         from city in cities.DefaultIfEmpty()
                         join device in Context.Devices on address.Id equals device.AddressId into devices
                         from device in devices.DefaultIfEmpty()
                         join model in Context.DeviceModels on device.DeviceModelId equals model.Id into models
                         from model in models.DefaultIfEmpty()
                         join brand in Context.DeviceBrands on model.DeviceBrandId equals brand.Id into brands
                         from brand in brands.DefaultIfEmpty()
                         join type in Context.DeviceTypes on brand.DeviceTypeId equals type.Id into types
                         from type in types.DefaultIfEmpty()
                         join ctemp in (from c in Context.Contracts
                                        where c.EndDate == Context.Contracts.Where(c2 => c2.DeviceId == c.DeviceId).Max(c2 => c2.EndDate)
                                        select c) on device.Id equals ctemp.DeviceId into devicesTemp
                         from ctemp in devicesTemp.DefaultIfEmpty()
                         where c.CompanyId == Utils.CompanyId &&
                               (!filter.CustomerId.HasValue || c.Id == filter.CustomerId) &&
                               (!filter.SehirId.HasValue || city.Id == filter.SehirId) &&
                               (!filter.IlceId.HasValue || district.Id == filter.IlceId) &&
                               (!filter.Model.HasValue || model.Id == filter.Model) &&
                               (string.IsNullOrEmpty(filter.SerialNo) || device.SerialNumber.Contains(filter.SerialNo)) &&
                               (filter.SozlesmeKodlari.Count == 0 || filter.SozlesmeKodlari.Any(s => s == ctemp.ContractCode)) &&
                               (!filter.BaslangicTarihi.HasValue || ctemp.StartDate >= filter.BaslangicTarihi) &&
                               (!filter.BitisTarihi.HasValue || ctemp.EndDate <= filter.BitisTarihi)
                         select new
                         {
                             Sehir = city != null ? city.Name : null,
                             Ilce = district != null ? district.Name : null,
                             Semt = address != null ? address.QuerterName : null,
                             AddressId = address != null ? address.Id : (long?)null,
                             Tip = type != null ? type.Name : null,
                             Marka = brand != null ? brand.Name : null,
                             Model = model != null ? model.Name : null,
                             CihazSeriNo = device != null ? device.SerialNumber : null,
                             MontajTarihi = device != null ? device.AssemblyDate : (DateTime?)null,
                             DeviceId = device != null ? device.Id : (long?)null,
                             Unvan = c.Title,
                             CustomerId = c.Id,
                             SozlesmeKodu = ctemp != null ? ctemp.ContractCode : null,
                             BaslangicTarihi = ctemp != null ? ctemp.StartDate.ToString("dd/MM/yyyy") : null,
                             BitisTarihi = ctemp != null ? ctemp.EndDate.ToString("dd/MM/yyyy") : null,
                             AcikAdres = address != null ? address.NetAddress : null,
                             Departman = address != null ? address.Department : null,

                         })
                .AsQueryable();

            var result = await query.ToListAsync(cancellationToken);

            foreach (var item in result)
            {
                CustomerReportDto customer = new CustomerReportDto()
                {
                    AddressId = item.AddressId,
                    Unvan = item.Unvan,
                    Sehir = item.Sehir,
                    Ilce = item.Ilce,
                    Semt = item.Semt,
                    Tip = item.Tip,
                    Marka = item.Marka,
                    Model = item.Model,
                    MontajTarihi = item.MontajTarihi?.ToString("dd/MM/yyyy"),
                    CihazSeriNo = item.CihazSeriNo,
                    BaslangicTarihi = item.BaslangicTarihi,
                    BitisTarihi = item.BitisTarihi,
                    SozlesmeKodu = item.SozlesmeKodu,
                    AcikAdres = item.AcikAdres,
                    Departman = item.Departman
                };

                list.Add(customer);
            }

            return list;
        }
    }
}
