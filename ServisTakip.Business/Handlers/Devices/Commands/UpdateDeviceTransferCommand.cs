using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Commands
{
    public class UpdateDeviceTransferCommand : IRequest<ResponseMessage<DeviceTransferDto>>
    {
        public DeviceTransferDto Model { get; set; }
        public class UpdateDeviceTransferCommandHandler : IRequestHandler<UpdateDeviceTransferCommand, ResponseMessage<DeviceTransferDto>>
        {
            public async Task<ResponseMessage<DeviceTransferDto>> Handle(UpdateDeviceTransferCommand request, CancellationToken cancellationToken)
            {
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var device = await deviceRepo.GetAsync(s => s.Id == request.Model.CihazId);
                device.AddressId = request.Model.TransferAdresId;
                deviceRepo.Update(device);
                await deviceRepo.SaveChangesAsync();

                return ResponseMessage<DeviceTransferDto>.Success();
            }
        }
    }
}
