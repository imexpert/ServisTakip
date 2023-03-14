using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Business.Handlers.Contracts.Queries
{
    public class GetContractByIdQuery : IRequest<ResponseMessage<ContractDto>>
    {
        public long Id { get; set; }
        public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery,ResponseMessage<ContractDto>>
        {
            public async Task<ResponseMessage<ContractDto>> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
            {
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var contractList = await contractRepo.GetAsync(s=>s.Id == request.Id);
                var result = mapper.Map<ContractDto>(contractList);
                return ResponseMessage<ContractDto>.Success(result);
            }
        }
    }
}
