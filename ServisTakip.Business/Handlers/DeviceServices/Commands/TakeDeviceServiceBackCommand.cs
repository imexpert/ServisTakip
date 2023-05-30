using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class TakeDeviceServiceBackCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class TakeDeviceServiceBackCommandHandler : IRequestHandler<TakeDeviceServiceBackCommand, ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(TakeDeviceServiceBackCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceService.UserId = null;
                deviceService.StatusCode = (int)StatusCodes.ServisKaydiTeknisyensiz;
                deviceService.UserAssignDate = null;

                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
