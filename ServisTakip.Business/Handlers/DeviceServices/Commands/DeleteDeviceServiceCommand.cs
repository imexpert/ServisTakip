namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class DeleteDeviceServiceCommand : IRequest<ResponseMessage<bool>>
    {
        public long Id { get; set; }
        public class DeleteDeviceServiceCommandHandler : IRequestHandler<DeleteDeviceServiceCommand, ResponseMessage<bool>>
        {
            public async Task<ResponseMessage<bool>> Handle(DeleteDeviceServiceCommand request, CancellationToken cancellationToken)
            {
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Id);
                Tools.DeviceServiceRepository.Delete(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                return ResponseMessage<bool>.Success(true);
            }
        }
    }
}
