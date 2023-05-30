using ServisTakip.Entities.DTOs.DeviceModels;

namespace ServisTakip.Business.Handlers.DeviceModels.Queries
{
    public class GetDeviceModelListWithBrandIdQuery : IRequest<ResponseMessage<List<DeviceModelDto>>>
    {
        public long DeviceBrandId { get; set; }
        public class GetDeviceModelListWithBrandIdQueryHandler : IRequestHandler<GetDeviceModelListWithBrandIdQuery, ResponseMessage<List<DeviceModelDto>>>
        {
            public async Task<ResponseMessage<List<DeviceModelDto>>> Handle(GetDeviceModelListWithBrandIdQuery request, CancellationToken cancellationToken)
            {
                var deviceModelList = await Tools.DeviceModelRepository.GetListAsync(s =>
                    s.DeviceBrandId == request.DeviceBrandId);
                var result = Tools.Mapper.Map<List<DeviceModelDto>>(deviceModelList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
