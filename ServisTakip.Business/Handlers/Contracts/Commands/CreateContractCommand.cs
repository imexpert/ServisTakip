using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.Contracts.Commands
{
    public class CreateContractCommand : IRequest<ResponseMessage<ContractDto>>
    {
        public CreateContractDto Model { get; set; }
        public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, ResponseMessage<ContractDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<ContractDto>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
            {
                #region Sözleşme Ekleme
                var contract = Tools.Mapper.Map<Contract>(request.Model);
                Tools.ContractRepository.Add(contract);
                await Tools.ContractRepository.SaveChangesAsync();
                #endregion

                #region Sözleşme Bakım Ekleme
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

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    DeviceId = contract.DeviceId
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                var result = Tools.Mapper.Map<ContractDto>(contract);
                return ResponseMessage<ContractDto>.Success(result);
            }
        }
    }
}