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
    public class GetToBeOfferedDeviceServicesListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public class GetToBeOfferedDeviceServicesListQueryHandler : IRequestHandler<GetToBeOfferedDeviceServicesListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetToBeOfferedDeviceServicesListQuery request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceServices =
                    await deviceServiceRepo.GetToBeOfferedDeviceServiceWithStatusCode(cancellationToken);
                var result = mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
