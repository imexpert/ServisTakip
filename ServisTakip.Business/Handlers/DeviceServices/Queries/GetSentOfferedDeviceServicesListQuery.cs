using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetSentOfferedDeviceServicesListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public class GetSentOfferedDeviceServicesListQueryHandler : IRequestHandler<GetSentOfferedDeviceServicesListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetSentOfferedDeviceServicesListQuery request, CancellationToken cancellationToken)
            {
                var deviceServices =
                    await Tools.DeviceServiceRepository.GetSentOfferedDeviceServiceWithStatusCode(cancellationToken);
                var result = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
