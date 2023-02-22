using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class TakeDeviceServiceBackCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class TakeDeviceServiceBackCommandHandler : IRequestHandler<TakeDeviceServiceBackCommand, ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(TakeDeviceServiceBackCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceService = await deviceServiceRepo.GetAsync(s => s.Id == request.Model.Id);
                deviceService.UserId = null;
                deviceService.StatusCode = (int)StatusCodes.ServisKaydiTeknisyensiz;
                deviceService.UserAssignDate = null;

                deviceServiceRepo.Update(deviceService);
                await deviceServiceRepo.SaveChangesAsync();

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
