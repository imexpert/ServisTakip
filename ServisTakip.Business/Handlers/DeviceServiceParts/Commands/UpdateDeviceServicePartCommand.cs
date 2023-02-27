using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Commands
{
    public class UpdateDeviceServicePartCommand : IRequest<ResponseMessage<CreateDeviceServicePartDto>>
    {
        public CreateDeviceServicePartDto Model { get; set; }
        public class UpdateDeviceServicePartCommandHandler : IRequestHandler<UpdateDeviceServicePartCommand, ResponseMessage<CreateDeviceServicePartDto>>
        {
            public async Task<ResponseMessage<CreateDeviceServicePartDto>> Handle(UpdateDeviceServicePartCommand request, CancellationToken cancellationToken)
            {
                var deviceServicePartRepo = ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceServicePart = await deviceServicePartRepo.GetAsync(s => s.Id == request.Model.Id);
                deviceServicePart.UnitPrice = request.Model.UnitPrice;
                deviceServicePart.NumberOfProduct = request.Model.NumberOfProduct;
                deviceServicePart.CurrencyType = request.Model.CurrencyType;
                deviceServicePart.Description = request.Model.Description;
                deviceServicePart.ProductCode = request.Model.ProductCode;
                deviceServicePart.ProductName = request.Model.ProductName;

                deviceServicePartRepo.Update(deviceServicePart);
                await deviceServicePartRepo.SaveChangesAsync();
                return ResponseMessage<CreateDeviceServicePartDto>.Success();
            }
        }
    }
}