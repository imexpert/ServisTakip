using ServisTakip.Entities.DTOs.Cities;

namespace ServisTakip.Business.Handlers.Cities.Queries
{
    public class GetCityListQuery : IRequest<ResponseMessage<List<CityDto>>>
    {
        public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, ResponseMessage<List<CityDto>>>
        {
            public async Task<ResponseMessage<List<CityDto>>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
            {
                var cityList = await Tools.CityRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<CityDto>>(cityList);
                return ResponseMessage<List<CityDto>>.Success(result);
            }
        }
    }
}
