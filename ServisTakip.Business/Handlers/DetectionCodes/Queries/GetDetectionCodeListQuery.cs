using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DetectionCodes;

namespace ServisTakip.Business.Handlers.DetectionCodes.Queries
{
    public class GetDetectionCodeListQuery : IRequest<ResponseMessage<List<DetectionCodeDto>>>
    {
        public class GetDetectionCodeListQueryHandler : IRequestHandler<GetDetectionCodeListQuery, ResponseMessage<List<DetectionCodeDto>>>
        {
            public async Task<ResponseMessage<List<DetectionCodeDto>>> Handle(GetDetectionCodeListQuery request, CancellationToken cancellationToken)
            {
                var detectionRepo = ServiceTool.ServiceProvider.GetService<IDetectionCodeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var detectionList = await detectionRepo.GetListAsync();
                var result = mapper.Map<List<DetectionCodeDto>>(detectionList);
                return ResponseMessage<List<DetectionCodeDto>>.Success(result);
            }
        }
    }
}
