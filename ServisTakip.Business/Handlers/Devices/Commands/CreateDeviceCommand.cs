using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Validations;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Business.Handlers.Devices.Commands
{
    public class CreateDeviceCommand : IRequest<ResponseMessage<DeviceDto>>
    {
        public CreateDeviceDto Model { get; set; }
        public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, ResponseMessage<DeviceDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<DeviceDto>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
            {
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var contractMaintenancesRepo = ServiceTool.ServiceProvider.GetService<IContractMaintenanceRepository>();

                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                #region Cihaz Ekleme
                var device = mapper.Map<Device>(request.Model);
                deviceRepo.Add(device);
                await deviceRepo.SaveChangesAsync();
                #endregion

                #region Cihaz Sözleşme Ekleme
                var contract = new Contract()
                {
                    ContractCode = "GAR-MON",
                    MaintenancePeriod = request.Model.MaintenancePeriod,
                    DeviceId = device.Id,
                    EndDate = device.AssemblyDate.AddYears(2),
                    StartDate = device.AssemblyDate,
                    Status = true,
                };
                contractRepo.Add(contract);
                await contractRepo.SaveChangesAsync();
                #endregion

                #region Cihaz Sözleşme Bakım Ekleme
                List<ContractMaintenance> contractMaintenances= new List<ContractMaintenance>();

                DateTime dt = device.AssemblyDate.AddMonths(request.Model.MaintenancePeriod);

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
                #endregion

                var deviceDto = mapper.Map<DeviceDto>(device);
                return ResponseMessage<DeviceDto>.Success(deviceDto);
            }
        }
    }
}
