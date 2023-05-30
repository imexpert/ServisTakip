using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceByModelNameFilterQuery : IRequest<ResponseMessage<List<SearchCustomerDto>>>
    {
        public string Filter { get; set; }
        public class GetDeviceByModelNameFilterQueryHandler : IRequestHandler<GetDeviceByModelNameFilterQuery, ResponseMessage<List<SearchCustomerDto>>>
        {
            public async Task<ResponseMessage<List<SearchCustomerDto>>> Handle(GetDeviceByModelNameFilterQuery request, CancellationToken cancellationToken)
            {
                List<SearchCustomerDto> result = new List<SearchCustomerDto>();

                var deviceList = await Tools.DeviceRepository.GetDeviceByModelNameFilterAsync(request.Filter, cancellationToken);
                foreach (var device in deviceList)
                {
                    var cst = new SearchCustomerDto
                    {
                        Title = device.Address.Customer.Title,
                        Id = device.Address.Customer.Id,
                        Sector = device.Address.Customer.Sector.Name,
                        AddressId = device.Address.Id,
                        DeviceId = device.Id,
                        Address = device.Address.AddressTitle,
                        District = device.Address.District.Name,
                        Model = device.DeviceModel.Name,
                        SerialNo = device.SerialNumber,
                        Department = device.Address.Department
                    };

                    result.Add(cst);
                }

                foreach (var item in result)
                {
                    item.RowId = $"{item.Id}|{item.AddressId}|{item.DeviceId}";
                }

                return ResponseMessage<List<SearchCustomerDto>>.Success(result);
            }
        }
    }
}
