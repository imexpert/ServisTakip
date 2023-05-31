using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.Devices.Commands
{
    public class UpdateDeviceCommand : IRequest<ResponseMessage<UpdateDeviceDto>>
    {
        public UpdateDeviceDto Model { get; set; }
        public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, ResponseMessage<UpdateDeviceDto>>
        {
            public async Task<ResponseMessage<UpdateDeviceDto>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
            {
                var device = Tools.Mapper.Map<Device>(request.Model);
                Tools.DeviceRepository.Update(device);
                await Tools.DeviceRepository.SaveChangesAsync();

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    DeviceId = device.Id,
                    AddressId = device.AddressId,
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<UpdateDeviceDto>.Success();
            }
        }
    }
}
