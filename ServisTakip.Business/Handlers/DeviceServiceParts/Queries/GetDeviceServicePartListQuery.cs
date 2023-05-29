using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Queries
{
    public class GetDeviceServicePartListQuery : IRequest<ResponseMessage<List<DeviceServicePartDto>>>
    {
        public long DeviceServiceId { get; set; }
        public class GetDeviceServicePartListQueryHandler : IRequestHandler<GetDeviceServicePartListQuery, ResponseMessage<List<DeviceServicePartDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServicePartDto>>> Handle(GetDeviceServicePartListQuery request, CancellationToken cancellationToken)
            {
                var deviceServicePartList = await Tools.DeviceServicePartRepository.GetListAsync(s => s.DeviceServiceId == request.DeviceServiceId);
                var result = Tools.Mapper.Map<List<DeviceServicePartDto>>(deviceServicePartList);
                return ResponseMessage<List<DeviceServicePartDto>>.Success(result);
            }
        }
    }
}