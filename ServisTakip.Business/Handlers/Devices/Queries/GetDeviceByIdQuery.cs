using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceByIdQuery : IRequest<ResponseMessage<DeviceDto>>
    {
        public long DeviceId { get; set; }
        public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, ResponseMessage<DeviceDto>>
        {
            public async Task<ResponseMessage<DeviceDto>> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
            {
                var device = await Tools.DeviceRepository.GetDeviceInfo(request.DeviceId);
                var result = Tools.Mapper.Map<DeviceDto>(device);
                return ResponseMessage<DeviceDto>.Success(result);
            }
        }
    }
}
