using Microsoft.EntityFrameworkCore;
using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CreateDeviceServicesCommand : IRequest<ResponseMessage<CreateDeviceServiceDto>>
    {
        public CreateDeviceServiceDto Model { get; set; }
        public class CreateDeviceServicesCommandHandler : IRequestHandler<CreateDeviceServicesCommand, ResponseMessage<CreateDeviceServiceDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServiceDto>> Handle(CreateDeviceServicesCommand request, CancellationToken cancellationToken)
            {
                var anyServices = await Tools.DeviceServiceRepository
                    .Query()
                    .Where(s => s.StatusCode != (int)StatusCodes.TalepSonlandirildi && s.StatusCode != (int)StatusCodes.TalepIptalEdildi && s.DeviceId == request.Model.DeviceId)
                    .ToListAsync(cancellationToken: cancellationToken);
                
                if (anyServices.Any()) 
                    return ResponseMessage<CreateDeviceServiceDto>.Fail("Bu cihaz için açılmış servis kaydı mevcuttur.");
                
                

                var deviceService = Tools.Mapper.Map<DeviceService>(request.Model);
                deviceService.StatusCode = deviceService.UserId.HasValue ? (int)StatusCodes.TeknisyenAtandi : (int)StatusCodes.ServisKaydiTeknisyensiz;

                deviceService.UserAssignDate = deviceService.UserId.HasValue ? DateTime.Now : null;

                Tools.DeviceServiceRepository.Add(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    DeviceServiceId = deviceService.Id,
                    DeviceId = deviceService.DeviceId
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<CreateDeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
