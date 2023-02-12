using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var contractMaintenanceRepo = ServiceTool.ServiceProvider.GetService<IContractMaintenanceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var contractList = await contractMaintenanceRepo.GetListAsync(s => s.DeviceServiceId == request.DeviceServiceId);
                var result = mapper.Map<List<ContractMaintenanceDto>>(contractList);
                return ResponseMessage<List<ContractMaintenanceDto>>.Success(result);
            }
        }
    }
}