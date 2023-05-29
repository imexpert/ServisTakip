using ServisTakip.Entities.DTOs.DeviceBrands;

namespace ServisTakip.Business.Handlers.DeviceBrands.Queries
{
    public class GetDeviceBrandListWithTypeIdQuery : IRequest<ResponseMessage<List<DeviceBrandDto>>>
    {
        public long DeviceTypeId { get; set; }
        public class GetDeviceBrandListWithTypeIdQueryHandler : IRequestHandler<GetDeviceBrandListWithTypeIdQuery, ResponseMessage<List<DeviceBrandDto>>>
        {
            public async Task<ResponseMessage<List<DeviceBrandDto>>> Handle(GetDeviceBrandListWithTypeIdQuery request, CancellationToken cancellationToken)
            {
                var deviceBrandList = await Tools.DeviceBrandRepository.GetListAsync(s =>
                    s.DeviceTypeId == request.DeviceTypeId);
                var result = Tools.Mapper.Map<List<DeviceBrandDto>>(deviceBrandList);
                return ResponseMessage<List<DeviceBrandDto>>.Success(result);
            }
        }
    }
}
