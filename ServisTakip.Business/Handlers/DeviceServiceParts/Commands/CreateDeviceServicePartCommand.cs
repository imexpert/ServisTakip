using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Commands
{
    public class CreateDeviceServicePartCommand : IRequest<ResponseMessage<CreateDeviceServicePartDto>>
    {
        public CreateDeviceServicePartDto Model { get; set; }
        public class CreateDeviceServicePartCommandHandler : IRequestHandler<CreateDeviceServicePartCommand, ResponseMessage<CreateDeviceServicePartDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServicePartDto>> Handle(CreateDeviceServicePartCommand request, CancellationToken cancellationToken)
            {
                var deviceServicePartRepo = ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceServicePart = mapper.Map<DeviceServicePart>(request.Model);
                deviceServicePartRepo.Add(deviceServicePart);
                await deviceServicePartRepo.SaveChangesAsync();
                return ResponseMessage<CreateDeviceServicePartDto>.Success();
            }
        }
    }
}