using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Business.Handlers.Contracts.Queries
{
    public class GetContractListQuery : IRequest<ResponseMessage<List<ContractDto>>>
    {
        public long DeviceId { get; set; }
        public class GetContractListQueryHandler : IRequestHandler<GetContractListQuery,ResponseMessage<List<ContractDto>>>
        {
            public async Task<ResponseMessage<List<ContractDto>>> Handle(GetContractListQuery request, CancellationToken cancellationToken)
            {
                var contractList = await Tools.ContractRepository.GetContractList(request.DeviceId);
                var result = Tools.Mapper.Map<List<ContractDto>>(contractList);
                result = result.OrderByDescending(s => s.EndDate).ToList();
                return ResponseMessage<List<ContractDto>>.Success(result);
            }
        }
    }
}
