using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetDeviceServiceQuery : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public long DeviceServiceId { get; set; }
        public class GetDeviceServiceQueryHandler : IRequestHandler<GetDeviceServiceQuery,ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(GetDeviceServiceQuery request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetDeviceServiceWithId(request.DeviceServiceId, cancellationToken);
                var result = Tools.Mapper.Map<DeviceServiceDto>(deviceService);
                return ResponseMessage<DeviceServiceDto>.Success(result);
            }
        }
    }
}
