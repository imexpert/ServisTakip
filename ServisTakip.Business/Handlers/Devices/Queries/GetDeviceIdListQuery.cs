using Microsoft.EntityFrameworkCore;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceIdListQuery : IRequest<ResponseMessage<List<long>>>
    {
        public string Filter { get; set; }
        public class GetDeviceIdListQueryHandler : IRequestHandler<GetDeviceIdListQuery, ResponseMessage<List<long>>>
        {
            public async Task<ResponseMessage<List<long>>> Handle(GetDeviceIdListQuery request, CancellationToken cancellationToken)
            {
                var deviceList = await Tools.DeviceRepository.Query()
                    .Include(s => s.Address).ThenInclude(s => s.Customer)
                    .Where(s => s.Address.Customer.CompanyId == Utils.CompanyId)
                    .Select(s => s.Id)
                    .ToListAsync(cancellationToken: cancellationToken);

                return ResponseMessage<List<long>>.Success(deviceList);
            }
        }
    }
}
