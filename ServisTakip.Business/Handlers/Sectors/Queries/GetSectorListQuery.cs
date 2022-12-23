using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Sectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Business.Handlers.Sectors.Queries
{
    public class GetSectorListQuery : IRequest<ResponseMessage<List<SectorDto>>>
    {
        public class GetSectorListQueryHandler : IRequestHandler<GetSectorListQuery, ResponseMessage<List<SectorDto>>>
        {
            public async Task<ResponseMessage<List<SectorDto>>> Handle(GetSectorListQuery request, CancellationToken cancellationToken)
            {
                var sectorRepo = ServiceTool.ServiceProvider.GetService<ISectorRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var sectors = await sectorRepo.GetListAsync(s => s.Status);
                var result = mapper.Map<List<SectorDto>>(sectors);
                return ResponseMessage<List<SectorDto>>.Success(result);
            }
        }
    }
}
