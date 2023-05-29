using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetReceivedDeviceServicesListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public class GetReceivedDeviceServicesListQueryHandler : IRequestHandler<GetReceivedDeviceServicesListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetReceivedDeviceServicesListQuery request, CancellationToken cancellationToken)
            {
                var deviceServices =
                    await Tools.DeviceServiceRepository.GetDeviceServiceWithStatusCode((int)StatusCodes.ServisKaydiTeknisyensiz);
                var result = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
