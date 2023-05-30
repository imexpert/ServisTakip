using ServisTakip.Entities.DTOs.ContractMaintenances;

namespace ServisTakip.Business.Handlers.ContractMaintenances.Queries
{
    public class GetContractMaintenanceListQuery : IRequest<ResponseMessage<List<ContractMaintenanceDto>>>
    {
        public long DeviceServiceId { get; set; }
        public long DeviceId { get; set; }
        public class GetContractMaintenanceListQueryHandler : IRequestHandler<GetContractMaintenanceListQuery,ResponseMessage<List<ContractMaintenanceDto>>>
        {
            public async Task<ResponseMessage<List<ContractMaintenanceDto>>> Handle(GetContractMaintenanceListQuery request, CancellationToken cancellationToken)
            {
                var contractList = await Tools.ContractMaintenanceRepository.GetListAsync(s => s.DeviceServiceId == request.DeviceServiceId);
                var result = Tools.Mapper.Map<List<ContractMaintenanceDto>>(contractList);
                return ResponseMessage<List<ContractMaintenanceDto>>.Success(result);
            }
        }
    }
}