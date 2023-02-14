﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CreateDeviceServicesCommand : IRequest<ResponseMessage<CreateDeviceServiceDto>>
    {
        public CreateDeviceServiceDto Model { get; set; }
        public class CreateDeviceServicesCommandHandler : IRequestHandler<CreateDeviceServicesCommand, ResponseMessage<CreateDeviceServiceDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServiceDto>> Handle(CreateDeviceServicesCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();

                var anyServices = await deviceServiceRepo
                    .Query()
                    .Where(s => s.StatusCode != (int)StatusCodes.ServisKaydiKapatildi)
                    .ToListAsync();
                
                if (anyServices.Any()) 
                    return ResponseMessage<CreateDeviceServiceDto>.Fail("Bu cihaz için açılmış servis kaydı mevcuttur.");
                
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceService = mapper.Map<DeviceService>(request.Model);
                deviceService.StatusCode = deviceService.UserId.HasValue ? (int)StatusCodes.TeknisyenAtandi : (int)StatusCodes.ServisAcildi;

                deviceService.UserAssignDate = deviceService.UserId.HasValue ? DateTime.Now : null;

                deviceServiceRepo.Add(deviceService);
                await deviceServiceRepo.SaveChangesAsync();
                return ResponseMessage<CreateDeviceServiceDto>.Success(request.Model);
            }
        }
    }
}