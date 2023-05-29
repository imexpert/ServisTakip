using ServisTakip.Entities.DTOs.DeviceModels;

namespace ServisTakip.Business.Handlers.DeviceModels.Queries
{
    public class GetDeviceModelListQuery : IRequest<ResponseMessage<List<DeviceModelDto>>>
    {
        public class GetDeviceModelListQueryHandler : IRequestHandler<GetDeviceModelListQuery, ResponseMessage<List<DeviceModelDto>>>
        {
            public async Task<ResponseMessage<List<DeviceModelDto>>> Handle(GetDeviceModelListQuery request, CancellationToken cancellationToken)
            {
                var deviceModelList = await Tools.DeviceModelRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<DeviceModelDto>>(deviceModelList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
