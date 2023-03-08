using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
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
                var deviceTypeRepo = ServiceTool.ServiceProvider.GetService<IDeviceTypeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceTypeList = await deviceTypeRepo.GetListAsync(s => s.CompanyId == Utils.CompanyId);
                var result = mapper.Map<List<DeviceTypeDto>>(deviceTypeList);
                return ResponseMessage<List<DeviceTypeDto>>.Success(result);
            }
        }
    }
}
