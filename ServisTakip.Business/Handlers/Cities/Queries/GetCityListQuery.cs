using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Cities;

namespace ServisTakip.Business.Handlers.Cities.Queries
{
    public class GetCityListQuery : IRequest<ResponseMessage<List<CityDto>>>
    {
        public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, ResponseMessage<List<CityDto>>>
        {
            public async Task<ResponseMessage<List<CityDto>>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
            {
                var cityRepo = ServiceTool.ServiceProvider.GetService<ICityRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var cityList = await cityRepo.GetListAsync();
                var result = mapper.Map<List<CityDto>>(cityList);
                return ResponseMessage<List<CityDto>>.Success(result);
            }
        }
    }
}
