using AutoMapper;
using MediatR;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceBrands;
using Microsoft.Extensions.DependencyInjection;

namespace ServisTakip.Business.Handlers.DeviceBrands.Queries
{
    public class GetDeviceBrandListQuery : IRequest<ResponseMessage<List<DeviceBrandDto>>>
    {
        public class GetDeviceBrandListQueryHandler : IRequestHandler<GetDeviceBrandListQuery, ResponseMessage<List<DeviceBrandDto>>>
        {
            public async Task<ResponseMessage<List<DeviceBrandDto>>> Handle(GetDeviceBrandListQuery request, CancellationToken cancellationToken)
            {
                var cityRepo = ServiceTool.ServiceProvider.GetService<IDeviceBrandRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var cityList = await cityRepo.GetListAsync();
                var result = mapper.Map<List<DeviceBrandDto>>(cityList);
                return ResponseMessage<List<DeviceBrandDto>>.Success(result);
            }
        }
    }
}
