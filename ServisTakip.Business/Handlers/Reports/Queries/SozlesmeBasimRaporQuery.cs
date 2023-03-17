using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class SozlesmeBasimRaporQuery : IRequest<ResponseMessage<List<ContractDto>>>
    {
        public SozlesmeBasimRaporFilter Model { get; set; }
        public class SozlesmeBasimRaporQueryHandler : IRequestHandler<SozlesmeBasimRaporQuery, ResponseMessage<List<ContractDto>>>
        {
            public async Task<ResponseMessage<List<ContractDto>>> Handle(SozlesmeBasimRaporQuery request, CancellationToken cancellationToken)
            {
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var contracts = await contractRepo.GetSozlesmeBasimListAsync(request.Model, cancellationToken);
                var result = mapper.Map<List<ContractDto>>(contracts);
                return ResponseMessage<List<ContractDto>>.Success(result);
            }
        }
    }
}
