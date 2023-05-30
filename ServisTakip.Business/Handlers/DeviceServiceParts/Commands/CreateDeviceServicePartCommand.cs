using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Commands
{
    public class CreateDeviceServicePartCommand : IRequest<ResponseMessage<CreateDeviceServicePartDto>>
    {
        public CreateDeviceServicePartDto Model { get; set; }
        public class CreateDeviceServicePartCommandHandler : IRequestHandler<CreateDeviceServicePartCommand, ResponseMessage<CreateDeviceServicePartDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServicePartDto>> Handle(CreateDeviceServicePartCommand request, CancellationToken cancellationToken)
            {
                var deviceServicePart = Tools.Mapper.Map<DeviceServicePart>(request.Model);
                Tools.DeviceServicePartRepository.Add(deviceServicePart);
                await Tools.DeviceServicePartRepository.SaveChangesAsync();
                return ResponseMessage<CreateDeviceServicePartDto>.Success();
            }
        }
    }
}