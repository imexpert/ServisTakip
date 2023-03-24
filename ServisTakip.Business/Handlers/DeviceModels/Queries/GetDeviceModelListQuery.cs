using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceModels;

namespace ServisTakip.Business.Handlers.DeviceModels.Queries
{
    public class GetDeviceModelListQuery : IRequest<ResponseMessage<List<DeviceModelDto>>>
    {
        public class GetDeviceModelListQueryHandler : IRequestHandler<GetDeviceModelListQuery, ResponseMessage<List<DeviceModelDto>>>
        {
            public async Task<ResponseMessage<List<DeviceModelDto>>> Handle(GetDeviceModelListQuery request, CancellationToken cancellationToken)
            {
                var deviceModelRepo = ServiceTool.ServiceProvider.GetService<IDeviceModelRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceModelList = await deviceModelRepo.GetListAsync();
                var result = mapper.Map<List<DeviceModelDto>>(deviceModelList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
