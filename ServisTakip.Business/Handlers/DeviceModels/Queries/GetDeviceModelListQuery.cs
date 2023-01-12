using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
                var cityRepo = ServiceTool.ServiceProvider.GetService<IDeviceModelRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var cityList = await cityRepo.GetListAsync();
                var result = mapper.Map<List<DeviceModelDto>>(cityList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
