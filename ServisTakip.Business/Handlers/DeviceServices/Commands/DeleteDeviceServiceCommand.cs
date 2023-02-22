using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class DeleteDeviceServiceCommand : IRequest<ResponseMessage<bool>>
    {
        public long Id { get; set; }
        public class DeleteDeviceServiceCommandHandler : IRequestHandler<DeleteDeviceServiceCommand, ResponseMessage<bool>>
        {
            public async Task<ResponseMessage<bool>> Handle(DeleteDeviceServiceCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceService = await deviceServiceRepo.GetAsync(s => s.Id == request.Id);
                deviceServiceRepo.Delete(deviceService);
                await deviceServiceRepo.SaveChangesAsync();

                return ResponseMessage<bool>.Success(true);
            }
        }
    }
}
