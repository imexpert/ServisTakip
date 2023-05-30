using ServisTakip.Entities.DTOs.Districts;

namespace ServisTakip.Business.Handlers.Districts.Queries
{
    public class GetDistrictListQuery : IRequest<ResponseMessage<List<DistrictDto>>>
    {
        public long CityId { get; set; }
        public class GetDistrictListQueryHandler : IRequestHandler<GetDistrictListQuery, ResponseMessage<List<DistrictDto>>>
        {
            public async Task<ResponseMessage<List<DistrictDto>>> Handle(GetDistrictListQuery request, CancellationToken cancellationToken)
            {
                var districtList = await Tools.DistrictRepository.GetListAsync(s => s.CityId == request.CityId);
                var result = Tools.Mapper.Map<List<DistrictDto>>(districtList);
                return ResponseMessage<List<DistrictDto>>.Success(result);
            }
        }
    }
}
