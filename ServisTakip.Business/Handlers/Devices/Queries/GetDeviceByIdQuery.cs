using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceByIdQuery : IRequest<ResponseMessage<DeviceDto>>
    {
        public long DeviceId { get; set; }
        public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, ResponseMessage<DeviceDto>>
        {
            public async Task<ResponseMessage<DeviceDto>> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var device = await customerRepo.GetDeviceInfo(request.DeviceId);
                var result = mapper.Map<DeviceDto>(device);
                return ResponseMessage<DeviceDto>.Success(result);
            }
        }
    }
}
