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
    public class GetDeviceModelListWithBrandIdQuery : IRequest<ResponseMessage<List<DeviceModelDto>>>
    {
        public long DeviceBrandId { get; set; }
        public class GetDeviceModelListWithBrandIdQueryHandler : IRequestHandler<GetDeviceModelListWithBrandIdQuery, ResponseMessage<List<DeviceModelDto>>>
        {
            public async Task<ResponseMessage<List<DeviceModelDto>>> Handle(GetDeviceModelListWithBrandIdQuery request, CancellationToken cancellationToken)
            {
                var deviceModelRepo = ServiceTool.ServiceProvider.GetService<IDeviceModelRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceModelList = await deviceModelRepo.GetListAsync(s =>
                    s.DeviceBrandId == request.DeviceBrandId && s.CompanyId == Utils.CompanyId);
                var result = mapper.Map<List<DeviceModelDto>>(deviceModelList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
