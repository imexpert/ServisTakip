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

                var lastService = await Tools.DeviceServiceRepository.GetLastTradedCustomerInfo();
                if (lastService != null)
                {
                    result = new LastTradedCustomerInfoDto()
                    {
                        CustomerTitle = lastService.Device.Address.Customer.Title,
                        AddressId = lastService.Device.AddressId,
                        CustomerSector = lastService.Device.Address.Customer.Sector.Name,
                        AccountCode = lastService.Device.Address.AccountCode,
                        AuthorizedName = lastService.Device.Address.AuthorizedName,
                        AuthorizedPhone = lastService.Device.Address.AuthorizedPhone,
                        AuthorizedWorkPhone = lastService.Device.Address.AuthorizedWorkPhone,
                        AuthorizedTask = lastService.Device.Address.AuthorizedTask,
                        CityName = lastService.Device.Address.District.City.Name,
                        CustomerId = lastService.Device.Address.Customer.Id,
                        AuthorizedEmail = lastService.Device.Address.AuthorizedEmail,
                        DeviceId = lastService.DeviceId,
                        DistrictName = lastService.Device.Address.District.Name,
                        QuarterName = lastService.Device.Address.QuerterName,
                        Department = lastService.Device.Address.Department,
                        RegionCode = lastService.Device.Address.RegionCode,
                        Device = Tools.Mapper.Map<DeviceDto>(lastService.Device),
                        RowId = $"{lastService.Device.Address.Customer.Id}|{lastService.Device.Address.Id}|{lastService.DeviceId}"
                    };

                    var contracts = await Tools.ContractRepository.GetListAsync(s => s.DeviceId == result.DeviceId);
                    result.Contracts = Tools.Mapper.Map<List<ContractDto>>(contracts);

                    var lastContract = result.Contracts.MaxBy(s => s.EndDate);
                    if (lastContract != null && lastContract.EndDate >= DateTime.Now)
                    {
                        result.ContractType = lastContract?.ContractCode;

                        var contractMaintenances =
                            await Tools.ContractMaintenanceRepository.GetListAsync(s =>
                                s.ContractId == lastContract.Id && s.StartDate <= DateTime.Today &&
                                s.EndDate >= DateTime.Today && s.DeviceServiceId.HasValue);

                        result.MaintenanceStatus = contractMaintenances.Any();
                    }
                    else
                    {
                        result.ContractType = "ÜCRETLİ";
                    }

                    var deviceServices = await Tools.DeviceServiceRepository.GetDeviceServices(lastService.DeviceId);

                    result.DeviceServices = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices.Where(s => s.StatusCode == ((int)StatusCodes.TalepSonlandirildi)));

                    if (result.DeviceServices.Count > 0)
                    {
                        var service = result.DeviceServices.MaxBy(s => s.ResultDate);
                        result.WbCount = service.WBCount;
                        result.ColorCount = service.ColorCount;

                        result.Devices = Tools.Mapper.Map<List<DeviceDto>>(await Tools.DeviceRepository.GetAllDevices(result.CustomerId));

                        result.Devices.Select(c => { c.RowId = $"{result.CustomerId}|{c.AddressId}|{c.Id}"; return c; }).ToList();
                    }

                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                var lastDevice = await Tools.DeviceRepository.GetLastTradedCustomerInfo();
                if (lastDevice != null)
                {
                    result = new LastTradedCustomerInfoDto()
                    {
                        CustomerTitle = lastDevice.Address.Customer.Title,
                        AddressId = lastDevice.AddressId,
                        CustomerSector = lastDevice.Address.Customer.Sector.Name,
                        AccountCode = lastDevice.Address.AccountCode,
                        AuthorizedName = lastDevice.Address.AuthorizedName,
                        AuthorizedPhone = lastDevice.Address.AuthorizedPhone,
                        AuthorizedWorkPhone = lastDevice.Address.AuthorizedWorkPhone,
                        AuthorizedTask = lastDevice.Address.AuthorizedTask,
                        CityName = lastDevice.Address.District.City.Name,
                        CustomerId = lastDevice.Address.Customer.Id,
                        AuthorizedEmail = lastDevice.Address.AuthorizedEmail,
                        Department = lastDevice.Address.Department,
                        DeviceId = lastDevice.Id,
                        DistrictName = lastDevice.Address.District.Name,
                        QuarterName = lastDevice.Address.QuerterName,
                        RegionCode = lastDevice.Address.RegionCode,
                        Device = Tools.Mapper.Map<DeviceDto>(lastDevice),
                        RowId = $"{lastDevice.Address.Customer.Id}|{lastDevice.Address.Id}|{lastDevice.Id}"
                    };

                    var contracts = await Tools.ContractRepository.GetListAsync(s => s.DeviceId == result.DeviceId);
                    result.Contracts = Tools.Mapper.Map<List<ContractDto>>(contracts);

                    var lastContract = result.Contracts.MaxBy(s => s.EndDate);
                    result.ContractType = lastContract?.ContractCode;

                    if (lastContract != null)
                    {
                        var contractMaintenances =
                            await Tools.ContractMaintenanceRepository.GetListAsync(s =>
                                s.ContractId == lastContract.Id && s.StartDate <= DateTime.Today &&
                                s.EndDate >= DateTime.Today && s.DeviceServiceId.HasValue);

                        result.MaintenanceStatus = contractMaintenances.Any();
                    }
                    
                    result.Devices = Tools.Mapper.Map<List<DeviceDto>>(await Tools.DeviceRepository.GetAllDevices(result.CustomerId));
                    result.Devices.Select(c => { c.RowId = $"{result.CustomerId}|{c.AddressId}|{c.Id}"; return c; }).ToList();
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                var customerList = await Tools.CustomerRepository.GetCustomerListAsync(cancellationToken);

                var customer = customerList.FirstOrDefault(s => s.RecordUsername == Utils.Email);
                if (customer != null)
                {
                    result.CustomerTitle = customer.Title;
                    result.CustomerId = customer.Id;
                    result.CustomerSector = customer.Sector.Name;

                    if (customer.Addresses is { Count: > 0 })
                    {
                        var address = customer.Addresses.MaxBy(s => s.UpdateDate);
                        result.AddressId = address.Id;
                        result.AccountCode = address.AccountCode;
                        result.AuthorizedEmail = address.AuthorizedEmail;
                        result.AuthorizedName = address.AuthorizedName;
                        result.AuthorizedPhone = address.AuthorizedPhone;
                        result.AuthorizedWorkPhone = address.AuthorizedWorkPhone;
                        result.AuthorizedTask = address.AuthorizedTask;
                        result.Department = address.Department;
                        result.CityName = address.District.City.Name;
                        result.DistrictName = address.District.Name;
                        result.QuarterName = address.QuerterName;
                        result.RegionCode = address.RegionCode;
                        result.RowId = $"{customer.Id}|{address.Id}|{0}";
                    }
                    else
                    {
                        result.RowId = $"{customer.Id}|{0}|{0}";
                    }
                    
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                customer = customerList.MaxBy(s => s.RecordDate);

                result.CustomerTitle = customer.Title;
                result.CustomerId = customer.Id;
                result.CustomerSector = customer.Sector.Name;

                if (customer.Addresses is { Count: > 0 })
                {
                    var address = customer.Addresses.MaxBy(s => s.UpdateDate);
                    result.AddressId = address.Id;
                    result.AccountCode = address.AccountCode;
                    result.AuthorizedEmail = address.AuthorizedEmail;
                    result.AuthorizedName = address.AuthorizedName;
                    result.AuthorizedPhone = address.AuthorizedPhone;
                    result.AuthorizedWorkPhone = address.AuthorizedWorkPhone;
                    result.AuthorizedTask = address.AuthorizedTask;
                    result.Department = address.Department;
                    result.CityName = address.District.City.Name;
                    result.DistrictName = address.District.Name;
                    result.QuarterName = address.QuerterName;
                    result.RegionCode = address.RegionCode;
                    result.RowId = $"{customer.Id}|{address.Id}|{0}";
                }
                else
                {
                    result.RowId = $"{customer.Id}|{0}|{0}";
                }

                return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
            }
        }
    }
}
