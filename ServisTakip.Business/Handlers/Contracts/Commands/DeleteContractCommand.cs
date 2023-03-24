using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Business.Handlers.Contracts.Commands
{
    public class DeleteContractCommand : IRequest<ResponseMessage<ContractDto>>
    {
        public long Id { get; set; }
        public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, ResponseMessage<ContractDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<ContractDto>> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
            {
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var contractMaintenancesRepo = ServiceTool.ServiceProvider.GetService<IContractMaintenanceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var contract = await contractRepo.GetAsync(s => s.Id == request.Id);

                var listOfMaintenances = await contractMaintenancesRepo.GetListAsync(s => s.ContractId == contract.Id);
                contractMaintenancesRepo.DeleteRange(listOfMaintenances.ToList());
                await contractMaintenancesRepo.SaveChangesAsync();

                contractRepo.Delete(contract);
                await contractRepo.SaveChangesAsync();
                return ResponseMessage<ContractDto>.Success();
            }
        }
    }
}
