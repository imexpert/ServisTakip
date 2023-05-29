using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetClosedDeviceServicesListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public class GetClosedDeviceServicesListQueryHandler : IRequestHandler<GetClosedDeviceServicesListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetClosedDeviceServicesListQuery request, CancellationToken cancellationToken)
            {
                var deviceServices =
                    await Tools.DeviceServiceRepository.GetDeviceServiceWithStatusCode((int)StatusCodes.TalepKapatilacakIslereAtandi);
                var result = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
