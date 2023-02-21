using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetMainPageCustomerQuery : IRequest<ResponseMessage<LastTradedCustomerInfoDto>>
    {
        public string RowId { get; set; }
        public class GetMainPageCustomerQueryHandler : IRequestHandler<GetMainPageCustomerQuery, ResponseMessage<LastTradedCustomerInfoDto>>
        {
            public async Task<ResponseMessage<LastTradedCustomerInfoDto>> Handle(GetMainPageCustomerQuery request, CancellationToken cancellationToken)
            {
                LastTradedCustomerInfoDto result = new LastTradedCustomerInfoDto();
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var deviceServicesRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var addressRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var splitIds = request.RowId.Split('|').ToList();

                //Ana ekranda seçilen kaydın cihazı var ise
                if (Convert.ToInt32(splitIds[2]) > 0)
                {
                    var device = await deviceRepo.GetDeviceInfo(Convert.ToInt64(splitIds[2]));
                    result = new LastTradedCustomerInfoDto()
                    {
                        CustomerTitle = device.Address.Customer.Title,
                        CustomerSector = device.Address.Customer.Sector.Name,
                        AccountCode = device.Address.AccountCode,
                        AuthorizedName = device.Address.AuthorizedName,
                        AuthorizedPhone = device.Address.AuthorizedPhone,
                        AuthorizedTask = device.Address.AuthorizedTask,
                        CityName = device.Address.Querter.District.City.Name,
                        CustomerId = device.Address.Customer.Id,
                        AuthorizedEmail = device.Address.AuthorizedEmail,
                        DeviceId = device.Id,
                        DistrictName = device.Address.Querter.District.Name,
                        QuarterName = device.Address.Querter.Name,
                        RegionCode = device.Address.Querter.RegionCode,
                        DeviceDto = mapper.Map<DeviceDto>(device),
                        RowId = $"{device.Address.Customer.Id}|{device.Address.Id}|{device.Id}"
                    };

                    var contracts = await contractRepo.GetListAsync(s => s.DeviceId == result.DeviceId);
                    result.Contracts = mapper.Map<List<ContractDto>>(contracts);

                    var lastContract = result.Contracts.MaxBy(s => s.EndDate);
                    result.ContractType = lastContract?.ContractCode;

                    result.DeviceServices = mapper.Map<List<DeviceServiceDto>>(device.DeviceServices.Where(s => s.StatusCode == (int)StatusCodes.TalepSonlandirildi));
                    result.DeviceServices = result.DeviceServices.OrderByDescending(s => s.ResultDate).ToList();

                    var service = result.DeviceServices.FirstOrDefault();
                    result.WbCount = service.WBCount;
                    result.ColorCount = service.ColorCount;

                    result.Devices = mapper.Map<List<DeviceDto>>(await deviceRepo.GetAllDevices(result.CustomerId));
                    result.Devices.Select(c => { c.RowId = $"{result.CustomerId}|{c.AddressId}|{c.Id}"; return c; }).ToList();
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }
                else if (Convert.ToInt32(splitIds[1]) > 0)
                {
                    var address = await addressRepo.GetAddressInfo(Convert.ToInt64(splitIds[1]));
                    result.AccountCode = address.AccountCode;
                    result.AuthorizedName = address.AuthorizedName;
                    result.AuthorizedPhone = address.AuthorizedPhone;
                    result.AuthorizedTask = address.AuthorizedTask;
                    result.AuthorizedEmail = address.AuthorizedEmail;
                    result.CityName = address.Querter.District.City.Name;
                    result.DistrictName = address.Querter.District.Name;
                    result.QuarterName = address.Querter.Name;
                    result.RegionCode = address.Querter.RegionCode;
                    result.CustomerTitle = address.Customer.Title;
                    result.CustomerId = address.Customer.Id;
                    result.CustomerSector = address.Customer.Sector.Name;
                    result.RowId = $"{address.Customer.Id}|{0}|{0}";
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                var customer = await customerRepo.GetCustomerById(Convert.ToInt64(splitIds[0]));
                result.CustomerTitle = customer.Title;
                result.CustomerId = customer.Id;
                result.CustomerSector = customer.Sector.Name;
                result.RowId = $"{customer.Id}|{0}|{0}";
                return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
            }
        }
    }
}