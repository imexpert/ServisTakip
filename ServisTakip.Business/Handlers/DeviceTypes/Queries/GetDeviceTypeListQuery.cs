using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceTypes;

namespace ServisTakip.Business.Handlers.DeviceTypes.Queries
{
    public class GetDeviceTypeListQuery : IRequest<ResponseMessage<List<DeviceTypeDto>>>
    {
        public class GetDeviceTypeListQueryHandler : IRequestHandler<GetDeviceTypeListQuery, ResponseMessage<List<DeviceTypeDto>>>
        {
            public async Task<ResponseMessage<List<DeviceTypeDto>>> Handle(GetDeviceTypeListQuery request, CancellationToken cancellationToken)
            {
                var cityRepo = ServiceTool.ServiceProvider.GetService<IDeviceTypeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var cityList = await cityRepo.GetListAsync();
                var result = mapper.Map<List<DeviceTypeDto>>(cityList);
                return ResponseMessage<List<DeviceTypeDto>>.Success(result);
            }
        }
    }
}
