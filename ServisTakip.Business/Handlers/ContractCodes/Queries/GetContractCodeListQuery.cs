using ServisTakip.Entities.DTOs.ContractCodes;

namespace ServisTakip.Business.Handlers.ContractCodes.Queries
{
    public class GetContractCodeListQuery : IRequest<ResponseMessage<List<ContractCodeDto>>>
    {
        public class GetContractCodeListQueryHandler : IRequestHandler<GetContractCodeListQuery, ResponseMessage<List<ContractCodeDto>>>
        {
            public async Task<ResponseMessage<List<ContractCodeDto>>> Handle(GetContractCodeListQuery request, CancellationToken cancellationToken)
            {
                var contractCodeList = await Tools.ContractCodeRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<ContractCodeDto>>(contractCodeList);
                return ResponseMessage<List<ContractCodeDto>>.Success(result);
            }
        }
    }
}
