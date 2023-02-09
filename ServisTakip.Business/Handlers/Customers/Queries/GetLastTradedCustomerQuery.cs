using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetLastTradedCustomerQuery : IRequest<ResponseMessage<LastTradedCustomerInfoDto>>
    {
        public class GetLastTradedCustomerQueryHandler : IRequestHandler<GetLastTradedCustomerQuery, ResponseMessage<LastTradedCustomerInfoDto>>
        {
            public async Task<ResponseMessage<LastTradedCustomerInfoDto>> Handle(GetLastTradedCustomerQuery request, CancellationToken cancellationToken)
            {
                LastTradedCustomerInfoDto result = new LastTradedCustomerInfoDto();

                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                // Login olan kullanıcının açmış olduğu servis kaydı var mı ona bakıyoruz
                var deviceServicesRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var lastService = await deviceServicesRepo.GetLastTradedCustomerInfo();
                if (lastService != null)
                {
                    result = new LastTradedCustomerInfoDto()
                    {
                        CustomerTitle = lastService.Device.Address.Customer.Title,
                        CustomerSector = lastService.Device.Address.Customer.Sector.Name,
                        AccountCode = lastService.Device.Address.AccountCode,
                        AuthorizedName = lastService.Device.Address.AuthorizedName,
                        AuthorizedPhone = lastService.Device.Address.AuthorizedPhone,
                        AuthorizedTask = lastService.Device.Address.AuthorizedTask,
                        CityName = lastService.Device.Address.Querter.District.City.Name,
                        CustomerId = lastService.Device.Address.Customer.Id,
                        AuthorizedEmail = lastService.Device.Address.AuthorizedEmail,
                        DeviceId = lastService.DeviceId,
                        DistrictName = lastService.Device.Address.Querter.District.Name,
                        QuarterName = lastService.Device.Address.Querter.Name,
                        RegionCode = lastService.Device.Address.Querter.RegionCode,
                        DeviceDto = mapper.Map<DeviceDto>(lastService.Device),
                        RowId = $"{lastService.Device.Address.Customer.Id}|{lastService.Device.Address.Id}|{lastService.DeviceId}"
                    };

                    var contracts = await contractRepo.GetListAsync(s => s.DeviceId == result.DeviceId);
                    result.Contracts = mapper.Map<List<ContractDto>>(contracts);
                    result.DeviceServices = mapper.Map<List<DeviceServiceDto>>(lastService.DeviceServices);
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                // Login olan kullanıcının eklemiş olduğu cihaz kaydı var mı ona bakıyoruz
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var lastDevice = await deviceRepo.GetLastTradedCustomerInfo();
                if (lastDevice != null)
                {
                    result = new LastTradedCustomerInfoDto()
                    {
                        CustomerTitle = lastDevice.Address.Customer.Title,
                        CustomerSector = lastDevice.Address.Customer.Sector.Name,
                        AccountCode = lastDevice.Address.AccountCode,
                        AuthorizedName = lastDevice.Address.AuthorizedName,
                        AuthorizedPhone = lastDevice.Address.AuthorizedPhone,
                        AuthorizedTask = lastDevice.Address.AuthorizedTask,
                        CityName = lastDevice.Address.Querter.District.City.Name,
                        CustomerId = lastDevice.Address.Customer.Id,
                        AuthorizedEmail = lastDevice.Address.AuthorizedEmail,
                        DeviceId = lastDevice.Id,
                        DistrictName = lastDevice.Address.Querter.District.Name,
                        QuarterName = lastDevice.Address.Querter.Name,
                        RegionCode = lastDevice.Address.Querter.RegionCode,
                        DeviceDto = mapper.Map<DeviceDto>(lastDevice),
                        RowId = $"{lastDevice.Address.Customer.Id}|{lastDevice.Address.Id}|{lastDevice.Id}"
                    };

                    var contracts = await contractRepo.GetListAsync(s => s.DeviceId == result.DeviceId);
                    result.Contracts = mapper.Map<List<ContractDto>>(contracts);

                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var lastCustomerList = await customerRepo.GetListAsync(s => s.RecordUsername == Utils.Email);

                if (lastCustomerList != null && lastCustomerList.Any())
                {
                    var lastCustomer = lastCustomerList.OrderByDescending(s => s.RecordDate).First();
                    result.CustomerTitle = lastCustomer.Title;
                    result.CustomerId = lastCustomer.Id;
                    result.CustomerSector = lastCustomer.Sector.Name;
                    result.RowId = $"{lastCustomer.Id}|{0}|{0}";
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                return ResponseMessage<LastTradedCustomerInfoDto>.Fail("Son İşlem Bilgisi Alınamadı.");
            }
        }
    }
}
