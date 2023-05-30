using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CancelDeviceServiceCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class CancelDeviceServiceCommandHandler : IRequestHandler<CancelDeviceServiceCommand, ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(CancelDeviceServiceCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceService.StatusCode = (int)StatusCodes.TalepIptalEdildi;
                deviceService.CancelDescription = request.Model.CancelDescription;

                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
