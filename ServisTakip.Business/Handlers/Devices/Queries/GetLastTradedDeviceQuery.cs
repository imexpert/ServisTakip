using ServisTakip.Business.Handlers.Customers.Queries;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetLastTradedDeviceQuery 
        : IRequest<ResponseMessage<LastTradedCustomerInfoDto>>
    {
        public class GetLastTradedDeviceQueryHandler
            : IRequestHandler<GetLastTradedCustomerQuery, ResponseMessage<LastTradedCustomerInfoDto>>
        {
            public async Task<ResponseMessage<LastTradedCustomerInfoDto>> Handle(GetLastTradedCustomerQuery request, CancellationToken cancellationToken)
            {
                LastTradedCustomerInfoDto result = new LastTradedCustomerInfoDto();

                var lastDevice = await Tools.DeviceRepository.GetLastTradedCustomerInfo();

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
        }
    }
}
