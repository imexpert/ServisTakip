using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.BootCodes;

namespace ServisTakip.Business.Handlers.BootCodes.Queries
{
    public class GetBootCodeListQuery : IRequest<ResponseMessage<List<BootCodeDto>>>
    {
        public class GetBootCodeListQueryHandler : IRequestHandler<GetBootCodeListQuery, ResponseMessage<List<BootCodeDto>>>
        {
            public async Task<ResponseMessage<List<BootCodeDto>>> Handle(GetBootCodeListQuery request, CancellationToken cancellationToken)
            {
                var cityRepo = ServiceTool.ServiceProvider.GetService<IBootCodeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var cityList = await cityRepo.GetListAsync();
                var result = mapper.Map<List<BootCodeDto>>(cityList);
                return ResponseMessage<List<BootCodeDto>>.Success(result);
            }
        }
    }
}
