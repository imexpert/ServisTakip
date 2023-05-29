using ServisTakip.Entities.DTOs.DeviceModels;

namespace ServisTakip.Business.Handlers.DeviceModels.Queries
{
    public class GetModelByNameFilterQuery : IRequest<ResponseMessage<List<DeviceModelDto>>>
    {
        public string Filter { get; set; }
        public class GetModelByNameFilterQueryHandler : IRequestHandler<GetModelByNameFilterQuery, ResponseMessage<List<DeviceModelDto>>>
        {
            public async Task<ResponseMessage<List<DeviceModelDto>>> Handle(GetModelByNameFilterQuery request, CancellationToken cancellationToken)
            {
                List<DeviceModelDto> result = new List<DeviceModelDto>();
                var deviceList = await Tools.DeviceModelRepository.GetModelByFilterAsync(request.Filter, cancellationToken);
                result = Tools.Mapper.Map<List<DeviceModelDto>>(deviceList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
