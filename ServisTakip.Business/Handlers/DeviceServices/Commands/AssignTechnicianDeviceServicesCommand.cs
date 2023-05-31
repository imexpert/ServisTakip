using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class AssignTechnicianDeviceServicesCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class AssignTechnicianDeviceServicesCommandHandler : IRequestHandler<AssignTechnicianDeviceServicesCommand, ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(AssignTechnicianDeviceServicesCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceService.UserId = request.Model.UserId;
                deviceService.StatusCode = (int)StatusCodes.TeknisyenAtandi;
                deviceService.UserAssignDate = DateTime.Now;

                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    DeviceServiceId = deviceService.Id,
                    DeviceId = deviceService.DeviceId
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
