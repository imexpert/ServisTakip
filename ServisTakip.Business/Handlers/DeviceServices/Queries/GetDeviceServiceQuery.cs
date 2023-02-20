using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetDeviceServiceQuery : IRequest<ResponseMessage<DeviceServiceDto>>
    {
        public long DeviceServiceId { get; set; }
        public class GetDeviceServiceQueryHandler : IRequestHandler<GetDeviceServiceQuery,ResponseMessage<DeviceServiceDto>>
        {
            public async Task<ResponseMessage<DeviceServiceDto>> Handle(GetDeviceServiceQuery request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceService = await deviceServiceRepo.GetDeviceServiceWithId(request.DeviceServiceId, cancellationToken);
                var result = mapper.Map<DeviceServiceDto>(deviceService);
                return ResponseMessage<DeviceServiceDto>.Success(result);
            }
        }
    }
}
