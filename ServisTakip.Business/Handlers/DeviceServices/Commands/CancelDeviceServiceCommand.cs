using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CancelDeviceServiceCommand : IRequest<ResponseMessage<CancelDeviceServiceDto>>
    {
        public CancelDeviceServiceDto Model { get; set; }
        public class CancelDeviceServiceCommandHandler : IRequestHandler<CancelDeviceServiceCommand, ResponseMessage<CancelDeviceServiceDto>>
        {
            public async Task<ResponseMessage<CancelDeviceServiceDto>> Handle(CancelDeviceServiceCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceService.StatusCode = (int)StatusCodes.TalepIptalEdildi;
                deviceService.CancelDescription = request.Model.CancelDescription;

                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                return ResponseMessage<CancelDeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
