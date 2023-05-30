using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CloseDeviceServicesCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class CloseDeviceServicesCommandHandler : IRequestHandler<CloseDeviceServicesCommand, ResponseMessage<DeviceServiceDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(CloseDeviceServicesCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceService.DetectionCode = request.Model.DetectionCode;
                deviceService.DetectionDescription = request.Model.DetectionDescription;
                deviceService.ServiceResultCode = request.Model.ServiceResultCode;
                deviceService.ResultDate = request.Model.ResultDate;
                deviceService.ResultDescription = request.Model.ResultDescription;
                deviceService.WBCount = request.Model.WBCount;
                deviceService.ColorCount = request.Model.ColorCount;
                deviceService.TonerType = request.Model.TonerType;
                deviceService.BlackCount = request.Model.BlackCount;
                deviceService.BlueCount = request.Model.BlueCount;
                deviceService.YellowCount = request.Model.YellowCount;
                deviceService.RedCount = request.Model.RedCount;
                deviceService.Dr = request.Model.Dr;
                deviceService.Bc = request.Model.Bc;
                deviceService.Pa = request.Model.Pa;
                deviceService.Bk = request.Model.Bk;
                deviceService.Dv = request.Model.Dv;
                deviceService.Fs = request.Model.Fs;
                deviceService.Ak = request.Model.Ak;
                deviceService.StatusCode = (int)StatusCodes.TalepSonlandirildi;

                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                await Tools.Mediator.Send(new CreateOfferDeviceServicesCommand()
                {
                    ClosedDeviceService = deviceService
                }, cancellationToken);

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
