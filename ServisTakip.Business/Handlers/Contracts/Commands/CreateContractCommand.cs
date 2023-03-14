using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Contracts;

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
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var contractMaintenancesRepo = ServiceTool.ServiceProvider.GetService<IContractMaintenanceRepository>();

                #region Sözleşme Ekleme
                var contract = mapper.Map<Contract>(request.Model);
                contractRepo.Add(contract);
                await contractRepo.SaveChangesAsync();
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

                    contractMaintenancesRepo.AddRange(contractMaintenances);
                    await contractMaintenancesRepo.SaveChangesAsync();
                }
                #endregion

                var result = mapper.Map<ContractDto>(contract);
                return ResponseMessage<ContractDto>.Success(result);
            }
        }
    }
}