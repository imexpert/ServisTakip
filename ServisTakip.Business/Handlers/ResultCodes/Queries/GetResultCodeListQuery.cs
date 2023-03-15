using AutoMapper;
using MediatR;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.ResultCodes;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;

namespace ServisTakip.Business.Handlers.ResultCodes.Queries
{
    public class GetResultCodeListQuery : IRequest<ResponseMessage<List<ResultCodeDto>>>
    {
        public class GetResultCodeListQueryHandler : IRequestHandler<GetResultCodeListQuery, ResponseMessage<List<ResultCodeDto>>>
        {
            public async Task<ResponseMessage<List<ResultCodeDto>>> Handle(GetResultCodeListQuery request, CancellationToken cancellationToken)
            {
                var resultCodeRepo = ServiceTool.ServiceProvider.GetService<IResultCodeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var resultCodeList = await resultCodeRepo.GetListAsync();
                var result = mapper.Map<List<ResultCodeDto>>(resultCodeList);
                return ResponseMessage<List<ResultCodeDto>>.Success(result);
            }
        }
    }
}
