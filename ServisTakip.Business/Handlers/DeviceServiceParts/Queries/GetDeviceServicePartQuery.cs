using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Queries
{
    public class GetDeviceServicePartQuery : IRequest<ResponseMessage<DeviceServicePartDto>>
    {
        public long Id { get; set; }
        public class GetDeviceServicePartQueryHandler : IRequestHandler<GetDeviceServicePartQuery, ResponseMessage<DeviceServicePartDto>>
        {
            public async Task<ResponseMessage<DeviceServicePartDto>> Handle(GetDeviceServicePartQuery request, CancellationToken cancellationToken)
            {
                var deviceServicePartList = await Tools.DeviceServicePartRepository.GetAsync(s => s.Id == request.Id);
                var result = Tools.Mapper.Map<DeviceServicePartDto>(deviceServicePartList);
                return ResponseMessage<DeviceServicePartDto>.Success(result);
            }
        }
    }
}