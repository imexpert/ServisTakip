using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CreateOfferDeviceServicesCommand : IRequest<ResponseMessage<CreateDeviceServiceDto>>
    {
        public DeviceService ClosedDeviceService { get; set; }
        public class CreateOfferDeviceServicesCommandHandler : IRequestHandler<CreateOfferDeviceServicesCommand, ResponseMessage<CreateDeviceServiceDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServiceDto>> Handle(CreateOfferDeviceServicesCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

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
                }
                else
                {
                    deviceService.StatusCode = ((int)StatusCodes.TeklifGonderilecek);
                    deviceService.ServiceBootCode = "TEK-1";
                }

                deviceServiceRepo.Add(deviceService);
                await deviceServiceRepo.SaveChangesAsync();

                return ResponseMessage<CreateDeviceServiceDto>.Success(new CreateDeviceServiceDto());
            }
        }
    }
}
