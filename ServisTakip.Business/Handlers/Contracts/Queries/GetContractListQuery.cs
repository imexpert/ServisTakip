using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Business.Handlers.Contracts.Queries
{
    public class GetContractListQuery : IRequest<ResponseMessage<List<ContractDto>>>
    {
        public long DeviceId { get; set; }
        public class GetContractListQueryHandler : IRequestHandler<GetContractListQuery,ResponseMessage<List<ContractDto>>>
        {
            public async Task<ResponseMessage<List<ContractDto>>> Handle(GetContractListQuery request, CancellationToken cancellationToken)
            {
                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var contractList = await contractRepo.GetContractList(request.DeviceId);
                var result = mapper.Map<List<ContractDto>>(contractList);
                result = result.OrderByDescending(s => s.EndDate).ToList();
                return ResponseMessage<List<ContractDto>>.Success(result);
            }
        }
    }
}
