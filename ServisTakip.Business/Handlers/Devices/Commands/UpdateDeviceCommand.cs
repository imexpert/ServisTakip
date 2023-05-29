﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Commands
{
    public class UpdateDeviceCommand : IRequest<ResponseMessage<UpdateDeviceDto>>
    {
        public UpdateDeviceDto Model { get; set; }
        public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, ResponseMessage<UpdateDeviceDto>>
        {
            public async Task<ResponseMessage<UpdateDeviceDto>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
            {
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var device = mapper.Map<Device>(request.Model);
                deviceRepo.Update(device);
                await deviceRepo.SaveChangesAsync();

                return ResponseMessage<UpdateDeviceDto>.Success();
            }
        }
    }
}
