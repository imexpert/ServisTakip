using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Business.Handlers.Contracts.Commands
{
    public class UpdateContractCommand : IRequest<ResponseMessage<ContractDto>>
    {
        public UpdateContractDto Model { get; set; }
        public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, ResponseMessage<ContractDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<ContractDto>> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
            {
                #region Sözleşme Ekleme
                var contract = Tools.Mapper.Map<Contract>(request.Model);
                Tools.ContractRepository.Update(contract);
                await Tools.ContractRepository.SaveChangesAsync();
                #endregion

                #region Sözleşme Bakım Ekleme
                var listOfMaintenances = await Tools.ContractMaintenanceRepository.GetListAsync(s => s.ContractId == contract.Id);
                Tools.ContractMaintenanceRepository.DeleteRange(listOfMaintenances.ToList());
                await Tools.ContractMaintenanceRepository.SaveChangesAsync();

                if (contract.ContractCode == "GAR-MON")
                {
                    List<ContractMaintenance> contractMaintenances = new List<ContractMaintenance>();

                    DateTime dt = contract.StartDate;

                    while (dt < contract.EndDate)
                    {
                        var contractMaintenance = new ContractMaintenance()
                        {
                            ContractId = contract.Id,
                            StartDate = dt,
                            EndDate = dt.AddMonths(request.Model.MaintenancePeriod),
                        };
                        contractMaintenances.Add(contractMaintenance);
                        dt = contractMaintenance.EndDate.AddDays(1);
                    }

                    Tools.ContractMaintenanceRepository.AddRange(contractMaintenances);
                    await Tools.ContractMaintenanceRepository.SaveChangesAsync();
                }
                #endregion

                var result = Tools.Mapper.Map<ContractDto>(contract);
                return ResponseMessage<ContractDto>.Success(result);
            }
        }
    }
}
