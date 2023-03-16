using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.DeviceModels;

namespace ServisTakip.Business.Handlers.DeviceModels.Queries
{
    public class GetModelByNameFilterQuery : IRequest<ResponseMessage<List<DeviceModelDto>>>
    {
        public string Filter { get; set; }
        public class GetModelByNameFilterQueryHandler : IRequestHandler<GetModelByNameFilterQuery, ResponseMessage<List<DeviceModelDto>>>
        {
            public async Task<ResponseMessage<List<DeviceModelDto>>> Handle(GetModelByNameFilterQuery request, CancellationToken cancellationToken)
            {
                var deviceModelRepo = ServiceTool.ServiceProvider.GetService<IDeviceModelRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                List<DeviceModelDto> result = new List<DeviceModelDto>();
                var deviceList = await deviceModelRepo.GetModelByFilterAsync(request.Filter, cancellationToken);
                result = mapper.Map<List<DeviceModelDto>>(deviceList);
                return ResponseMessage<List<DeviceModelDto>>.Success(result);
            }
        }
    }
}
