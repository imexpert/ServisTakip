using AutoMapper;
using MediatR;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceBrands;
using Microsoft.Extensions.DependencyInjection;

namespace ServisTakip.Business.Handlers.DeviceBrands.Queries
{
    public class GetDeviceBrandListWithTypeIdQuery : IRequest<ResponseMessage<List<DeviceBrandDto>>>
    {
        public long DeviceTypeId { get; set; }
        public class GetDeviceBrandListWithTypeIdQueryHandler : IRequestHandler<GetDeviceBrandListWithTypeIdQuery, ResponseMessage<List<DeviceBrandDto>>>
        {
            public async Task<ResponseMessage<List<DeviceBrandDto>>> Handle(GetDeviceBrandListWithTypeIdQuery request, CancellationToken cancellationToken)
            {
                var deviceBrandRepo = ServiceTool.ServiceProvider.GetService<IDeviceBrandRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceBrandList = await deviceBrandRepo.GetListAsync(s =>
                    s.DeviceTypeId == request.DeviceTypeId);
                var result = mapper.Map<List<DeviceBrandDto>>(deviceBrandList);
                return ResponseMessage<List<DeviceBrandDto>>.Success(result);
            }
        }
    }
}
