using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceListByAddressIdQuery : IRequest<ResponseMessage<List<DeviceDto>>>
    {
        public long AddressId { get; set; }
        public class GetDeviceListByAddressIdQueryHandler : IRequestHandler<GetDeviceListByAddressIdQuery, ResponseMessage<List<DeviceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceDto>>> Handle(GetDeviceListByAddressIdQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceList = await customerRepo.GetDeviceListByAddressId(request.AddressId, cancellationToken);
                var result = mapper.Map<List<DeviceDto>>(deviceList);
                return ResponseMessage<List<DeviceDto>>.Success(result);
            }
        }
    }
}
