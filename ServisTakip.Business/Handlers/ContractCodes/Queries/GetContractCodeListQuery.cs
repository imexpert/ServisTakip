using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.ContractCodes;

namespace ServisTakip.Business.Handlers.ContractCodes.Queries
{
    public class GetContractCodeListQuery : IRequest<ResponseMessage<List<ContractCodeDto>>>
    {
        public class GetContractCodeListQueryHandler : IRequestHandler<GetContractCodeListQuery, ResponseMessage<List<ContractCodeDto>>>
        {
            public async Task<ResponseMessage<List<ContractCodeDto>>> Handle(GetContractCodeListQuery request, CancellationToken cancellationToken)
            {
                var contractCodeRepo = ServiceTool.ServiceProvider.GetService<IContractCodeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var bootCodeList = await contractCodeRepo.GetListAsync();
                var result = mapper.Map<List<ContractCodeDto>>(bootCodeList);
                return ResponseMessage<List<ContractCodeDto>>.Success(result);
            }
        }
    }
}
