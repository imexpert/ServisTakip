using ServisTakip.Entities.DTOs.Devices;

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

                return ResponseMessage<UpdateDeviceDto>.Success();
            }
        }
    }
}
