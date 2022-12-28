using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Querters;

namespace ServisTakip.Business.Handlers.Querters.Queries
{
    public class GetQuerterListQuery : IRequest<ResponseMessage<List<QuerterDto>>>
    {
        public long DistrictId { get; set; }
        public class GetQuerterListQueryHandler : IRequestHandler<GetQuerterListQuery, ResponseMessage<List<QuerterDto>>>
        {
            public async Task<ResponseMessage<List<QuerterDto>>> Handle(GetQuerterListQuery request, CancellationToken cancellationToken)
            {
                var querterRepo = ServiceTool.ServiceProvider.GetService<IQuerterRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var querterList = await querterRepo.GetListAsync(s=>s.DistrictId == request.DistrictId);
                var result = mapper.Map<List<QuerterDto>>(querterList);
                return ResponseMessage<List<QuerterDto>>.Success(result);
            }
        }
    }
}
