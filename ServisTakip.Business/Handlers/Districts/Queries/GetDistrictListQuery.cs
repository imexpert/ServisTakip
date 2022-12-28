using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var districtRepo = ServiceTool.ServiceProvider.GetService<IDistrictRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var districtList = await districtRepo.GetListAsync(s => s.CityId == request.CityId);
                var result = mapper.Map<List<DistrictDto>>(districtList);
                return ResponseMessage<List<DistrictDto>>.Success(result);
            }
        }
    }
}
