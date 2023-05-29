using ServisTakip.Entities.DTOs.DeviceTypes;

namespace ServisTakip.Business.Handlers.DeviceTypes.Queries
{
    public class GetDeviceTypeListQuery : IRequest<ResponseMessage<List<DeviceTypeDto>>>
    {
        public class GetDeviceTypeListQueryHandler : IRequestHandler<GetDeviceTypeListQuery, ResponseMessage<List<DeviceTypeDto>>>
        {
            public async Task<ResponseMessage<List<DeviceTypeDto>>> Handle(GetDeviceTypeListQuery request, CancellationToken cancellationToken)
            {
                var deviceTypeList = await Tools.DeviceTypeRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<DeviceTypeDto>>(deviceTypeList);
                return ResponseMessage<List<DeviceTypeDto>>.Success(result);
            }
        }
    }
}
