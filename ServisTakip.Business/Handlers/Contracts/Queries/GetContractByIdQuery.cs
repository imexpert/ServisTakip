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
                var contractList = await Tools.ContractRepository.GetAsync(s=>s.Id == request.Id);
                var result = Tools.Mapper.Map<ContractDto>(contractList);
                return ResponseMessage<ContractDto>.Success(result);
            }
        }
    }
}
