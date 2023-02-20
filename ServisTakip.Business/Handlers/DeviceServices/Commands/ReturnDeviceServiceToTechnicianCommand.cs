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
    public class ReturnDeviceServiceToTechnicianCommand : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public DeviceServiceDto Model { get; set; }
        public class ReturnDeviceServiceToTechnicianCommandHandler : IRequestHandler<ReturnDeviceServiceToTechnicianCommand, ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(ReturnDeviceServiceToTechnicianCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceService = await deviceServiceRepo.GetAsync(s => s.Id == request.Model.Id);
                deviceService.StatusCode = (int)StatusCodes.TeknisyenAtandi;
                deviceServiceRepo.Update(deviceService);
                await deviceServiceRepo.SaveChangesAsync();

                return ResponseMessage<DeviceServiceDto>.Success(request.Model);
            }
        }
    }
}
