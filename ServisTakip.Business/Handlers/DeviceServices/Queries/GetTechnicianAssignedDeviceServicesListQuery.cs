using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetTechnicianAssignedDeviceServicesListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public class GetTechnicianAssignedDeviceServicesListQueryHandler : IRequestHandler<GetTechnicianAssignedDeviceServicesListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetTechnicianAssignedDeviceServicesListQuery request, CancellationToken cancellationToken)
            {
                var deviceServices =
                    await Tools.DeviceServiceRepository.GetDeviceServiceWithStatusCode((int)StatusCodes.TeknisyenAtandi);
                var result = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
