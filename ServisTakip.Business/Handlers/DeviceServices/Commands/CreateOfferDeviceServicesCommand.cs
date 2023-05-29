using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CreateOfferDeviceServicesCommand : IRequest<ResponseMessage<CreateDeviceServiceDto>>
    {
        public DeviceService ClosedDeviceService { get; set; }
        public class CreateOfferDeviceServicesCommandHandler : IRequestHandler<CreateOfferDeviceServicesCommand, ResponseMessage<CreateDeviceServiceDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServiceDto>> Handle(CreateOfferDeviceServicesCommand request, CancellationToken cancellationToken)
            {
                var deviceService = new DeviceService()
                {
                    LinkedDeviceServiceId = request.ClosedDeviceService.Id,
                    DeviceId = request.ClosedDeviceService.DeviceId,
                    FailureDate = DateTime.Now,
                    Name= request.ClosedDeviceService.Name,
                    Phone= request.ClosedDeviceService.Phone,
                };

                if (request.ClosedDeviceService.ServiceResultCode == "PSK" || request.ClosedDeviceService.ServiceResultCode == "PSX")
                {
                    deviceService.StatusCode = ((int)StatusCodes.ParcaDegisimTalebi);
                    deviceService.ServiceBootCode = "PDY-01";

                    Tools.DeviceServiceRepository.Add(deviceService);
                    await Tools.DeviceServiceRepository.SaveChangesAsync();
                }
                else if(request.ClosedDeviceService.ServiceResultCode == "TEK")
                {
                    deviceService.StatusCode = ((int)StatusCodes.TeklifGonderilecek);
                    deviceService.ServiceBootCode = "TEK-1";

                    Tools.DeviceServiceRepository.Add(deviceService);
                    await Tools.DeviceServiceRepository.SaveChangesAsync();
                }

                return ResponseMessage<CreateDeviceServiceDto>.Success(new CreateDeviceServiceDto());
            }
        }
    }
}