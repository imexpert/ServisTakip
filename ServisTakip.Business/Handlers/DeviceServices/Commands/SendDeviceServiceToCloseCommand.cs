using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class SendDeviceServiceToCloseCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class SendDeviceServiceToCloseCommandHandler : IRequestHandler<SendDeviceServiceToCloseCommand, ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(SendDeviceServiceToCloseCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceService.StatusCode = (int)StatusCodes.TalepKapatilacakIslereAtandi;
                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
