using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceListByAddressIdQuery : IRequest<ResponseMessage<List<DeviceDto>>>
    {
        public long AddressId { get; set; }
        public class GetDeviceListByAddressIdQueryHandler : IRequestHandler<GetDeviceListByAddressIdQuery, ResponseMessage<List<DeviceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceDto>>> Handle(GetDeviceListByAddressIdQuery request, CancellationToken cancellationToken)
            {
                var deviceList = await Tools.DeviceRepository.GetDeviceListByAddressId(request.AddressId, cancellationToken);
                var result = Tools.Mapper.Map<List<DeviceDto>>(deviceList);
                return ResponseMessage<List<DeviceDto>>.Success(result);
            }
        }
    }
}
