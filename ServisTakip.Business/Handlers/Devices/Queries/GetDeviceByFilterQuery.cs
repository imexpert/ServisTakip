using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceByFilterQuery : IRequest<ResponseMessage<List<SearchCustomerDto>>>
    {
        public long DeviceId { get; set; }
        public class GetDeviceByFilterQueryHandler : IRequestHandler<GetDeviceByFilterQuery, ResponseMessage<List<SearchCustomerDto>>>
        {
            public async Task<ResponseMessage<List<SearchCustomerDto>>> Handle(GetDeviceByFilterQuery request, CancellationToken cancellationToken)
            {
                List<SearchCustomerDto> result = new List<SearchCustomerDto>();

                var deviceList = await Tools.DeviceRepository.GetDeviceByFilterAsync(request.DeviceId, cancellationToken);
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
