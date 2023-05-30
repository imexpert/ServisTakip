using ServisTakip.Core.Aspects.Autofac.Transaction;
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
                var contract = await Tools.ContractRepository.GetAsync(s => s.Id == request.Id);

                var listOfMaintenances = await Tools.ContractMaintenanceRepository.GetListAsync(s => s.ContractId == contract.Id);
                Tools.ContractMaintenanceRepository.DeleteRange(listOfMaintenances.ToList());
                await Tools.ContractMaintenanceRepository.SaveChangesAsync();

                Tools.ContractRepository.Delete(contract);
                await Tools.ContractRepository.SaveChangesAsync();
                return ResponseMessage<ContractDto>.Success();
            }
        }
    }
}
