using ServisTakip.Business.Handlers.Customers.Queries;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetLastTradedDeviceServiceQuery 
        : IRequest<ResponseMessage<LastTradedCustomerInfoDto>>
    {
        public class GetLastTradedDeviceServiceQueryHandler 
            : IRequestHandler<GetLastTradedCustomerQuery, ResponseMessage<LastTradedCustomerInfoDto>>
        {
            public async Task<ResponseMessage<LastTradedCustomerInfoDto>> Handle(GetLastTradedCustomerQuery request, CancellationToken cancellationToken)
            {
                LastTradedCustomerInfoDto result = new LastTradedCustomerInfoDto();

                var lastService = await Tools.DeviceServiceRepository.GetLastTradedCustomerInfo();

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
        }
    }
}
