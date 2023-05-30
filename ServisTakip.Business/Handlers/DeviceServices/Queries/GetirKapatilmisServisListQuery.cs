using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetirKapatilmisServisListQuery : IRequest<ResponseMessage<List<DeviceServiceDto>>>
    {
        public long DeviceId { get; set; }
        public class KapatilmisServisListQueryHandler : IRequestHandler<GetirKapatilmisServisListQuery,ResponseMessage<List<DeviceServiceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServiceDto>>> Handle(GetirKapatilmisServisListQuery request, CancellationToken cancellationToken)
            {
                var deviceServices =
                    await Tools.DeviceServiceRepository.GetDeviceServiceWithStatusCode((int)StatusCodes.TalepSonlandirildi);
                var result = Tools.Mapper.Map<List<DeviceServiceDto>>(deviceServices);
                return ResponseMessage<List<DeviceServiceDto>>.Success(result);
            }
        }
    }
}
