using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceByAddressIdQuery : IRequest<ResponseMessage<List<DeviceDto>>>
    {
        public long AddressId { get; set; }
        public class GetDeviceByAddressIdQueryHandler : IRequestHandler<GetDeviceByAddressIdQuery, ResponseMessage<List<DeviceDto>>>
        {
            public async Task<ResponseMessage<List<DeviceDto>>> Handle(GetDeviceByAddressIdQuery request, CancellationToken cancellationToken)
            {
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                List<DeviceDto> result = new List<DeviceDto>();

                var deviceList = await deviceRepo.GetDeviceByAddressIdAsync(request.AddressId, cancellationToken);                

                return ResponseMessage<List<DeviceDto>>.Success(result);
            }
        }
    }
}
