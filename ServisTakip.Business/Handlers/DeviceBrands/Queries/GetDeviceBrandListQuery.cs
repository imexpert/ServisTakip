using ServisTakip.Entities.DTOs.DeviceBrands;

namespace ServisTakip.Business.Handlers.DeviceBrands.Queries
{
    public class GetDeviceBrandListQuery : IRequest<ResponseMessage<List<DeviceBrandDto>>>
    {
        public class GetDeviceBrandListQueryHandler : IRequestHandler<GetDeviceBrandListQuery, ResponseMessage<List<DeviceBrandDto>>>
        {
            public async Task<ResponseMessage<List<DeviceBrandDto>>> Handle(GetDeviceBrandListQuery request, CancellationToken cancellationToken)
            {
                var deviceBrandList = await Tools.DeviceBrandRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<DeviceBrandDto>>(deviceBrandList);
                return ResponseMessage<List<DeviceBrandDto>>.Success(result);
            }
        }
    }
}
