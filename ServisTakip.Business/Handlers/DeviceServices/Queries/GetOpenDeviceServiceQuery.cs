using Microsoft.EntityFrameworkCore;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetOpenDeviceServiceQuery : IRequest<ResponseMessage<NoContent>>
    {
        public long DeviceId { get; set; }
        public class GetOpenDeviceServiceQueryHandler : IRequestHandler<GetOpenDeviceServiceQuery,ResponseMessage<NoContent>>
        {
            public async Task<ResponseMessage<NoContent>> Handle(GetOpenDeviceServiceQuery request, CancellationToken cancellationToken)
            {
                var anyServices = await Tools.DeviceServiceRepository
                    .Query()
                    .Where(s => s.StatusCode != (int)StatusCodes.TalepSonlandirildi && s.StatusCode != (int)StatusCodes.TalepIptalEdildi && s.DeviceId == request.DeviceId)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (anyServices.Any())
                    return ResponseMessage<NoContent>.Fail("Bu cihaz için açılmış servis kaydı mevcuttur.");

                return ResponseMessage<NoContent>.Success();
            }
        }
    }
}
