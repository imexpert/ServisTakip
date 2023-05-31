using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.UserProcesses;

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
                #region Cihaz Ekleme
                var isSerialNoExists = await Tools.DeviceRepository.GetDeviceBySeriNo(request.Model.SerialNumber);
                if (isSerialNoExists != null && isSerialNoExists.Id > 0)
                    return ResponseMessage<DeviceDto>.Fail("Bu seri no'ya sahip cihaz daha önce eklenmiş.");
                
                var device = Tools.Mapper.Map<Device>(request.Model);
                Tools.DeviceRepository.Add(device);
                await Tools.DeviceRepository.SaveChangesAsync();
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
                Tools.ContractRepository.Add(contract);
                await Tools.ContractRepository.SaveChangesAsync();
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

                Tools.ContractMaintenanceRepository.AddRange(contractMaintenances);
                await Tools.ContractMaintenanceRepository.SaveChangesAsync();
                #endregion

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    DeviceId = device.Id,
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                var deviceDto = Tools.Mapper.Map<DeviceDto>(device);
                return ResponseMessage<DeviceDto>.Success(deviceDto);
            }
        }
    }
}
