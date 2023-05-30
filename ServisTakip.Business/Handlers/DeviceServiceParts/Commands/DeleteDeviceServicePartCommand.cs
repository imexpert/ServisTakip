using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Commands
{
    public class DeleteDeviceServicePartCommand : IRequest<ResponseMessage<CreateDeviceServicePartDto>>
    {
        public long Id { get; set; }
        public class DeleteDeviceServicePartCommandHandler : IRequestHandler<DeleteDeviceServicePartCommand, ResponseMessage<CreateDeviceServicePartDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServicePartDto>> Handle(DeleteDeviceServicePartCommand request, CancellationToken cancellationToken)
            {
                var deviceServicePart = await Tools.DeviceServicePartRepository.GetAsync(s => s.Id == request.Id);

                Tools.DeviceServicePartRepository.Delete(deviceServicePart);
                await Tools.DeviceServicePartRepository.SaveChangesAsync();
                return ResponseMessage<CreateDeviceServicePartDto>.Success();
            }
        }
    }
}