using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServiceParts.Queries
{
    public class GetDeviceServicePartQuery : IRequest<ResponseMessage<DeviceServicePartDto>>
    {
        public long Id { get; set; }
        public class GetDeviceServicePartQueryHandler : IRequestHandler<GetDeviceServicePartQuery, ResponseMessage<DeviceServicePartDto>>
        {
            public async Task<ResponseMessage<DeviceServicePartDto>> Handle(GetDeviceServicePartQuery request, CancellationToken cancellationToken)
            {
                var deviceServicePartRepo = ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceServicePartList = await deviceServicePartRepo.GetAsync(s => s.Id == request.Id);
                var result = mapper.Map<DeviceServicePartDto>(deviceServicePartList);
                return ResponseMessage<DeviceServicePartDto>.Success(result);
            }
        }
    }
}