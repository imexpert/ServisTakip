using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Commands
{
    public class UpdateDeviceTransferCommand : IRequest<ResponseMessage<DeviceTransferDto>>
    {
        public DeviceTransferDto Model { get; set; }
        public class UpdateDeviceTransferCommandHandler : IRequestHandler<UpdateDeviceTransferCommand, ResponseMessage<DeviceTransferDto>>
        {
            public async Task<ResponseMessage<DeviceTransferDto>> Handle(UpdateDeviceTransferCommand request, CancellationToken cancellationToken)
            {
                var device = await Tools.DeviceRepository.GetAsync(s => s.Id == request.Model.CihazId);
                device.AddressId = request.Model.TransferAdresId;
                Tools.DeviceRepository.Update(device);
                await Tools.DeviceRepository.SaveChangesAsync();

                return ResponseMessage<DeviceTransferDto>.Success();
            }
        }
    }
}
