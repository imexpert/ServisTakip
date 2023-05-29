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
                var deviceServicePart = await Tools.DeviceServicePartRepository.GetAsync(s => s.Id == request.Model.Id);
                deviceServicePart.UnitPrice = request.Model.UnitPrice;
                deviceServicePart.NumberOfProduct = request.Model.NumberOfProduct;
                deviceServicePart.CurrencyType = request.Model.CurrencyType;
                deviceServicePart.Description = request.Model.Description;
                deviceServicePart.ProductCode = request.Model.ProductCode;
                deviceServicePart.ProductName = request.Model.ProductName;

                Tools.DeviceServicePartRepository.Update(deviceServicePart);
                await Tools.DeviceServicePartRepository.SaveChangesAsync();
                return ResponseMessage<CreateDeviceServicePartDto>.Success();
            }
        }
    }
}