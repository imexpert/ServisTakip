using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Queries
{
    public class GetDeviceServicePartListQuery : IRequest<ResponseMessage<List<DeviceServicePartDto>>>
    {
        public long DeviceServiceId { get; set; }
        public class GetDeviceServicePartListQueryHandler : IRequestHandler<GetDeviceServicePartListQuery, ResponseMessage<List<DeviceServicePartDto>>>
        {
            public async Task<ResponseMessage<List<DeviceServicePartDto>>> Handle(GetDeviceServicePartListQuery request, CancellationToken cancellationToken)
            {
                var deviceServicePartRepo = ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceServicePartList = await deviceServicePartRepo.GetListAsync(s => s.DeviceServiceId == request.DeviceServiceId);
                var result = mapper.Map<List<DeviceServicePartDto>>(deviceServicePartList);
                return ResponseMessage<List<DeviceServicePartDto>>.Success(result);
            }
        }
    }
}