using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetToBeOfferedDeviceServicesListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public class GetToBeOfferedDeviceServicesListQueryHandler : IRequestHandler<GetToBeOfferedDeviceServicesListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetToBeOfferedDeviceServicesListQuery request, CancellationToken cancellationToken)
            {
                var deviceServices =
                    await Tools.DeviceServiceRepository.GetToBeOfferedDeviceServiceWithStatusCode(cancellationToken);
                var result = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
