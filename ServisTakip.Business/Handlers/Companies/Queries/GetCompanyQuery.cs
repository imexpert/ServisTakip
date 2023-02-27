using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Companies;

namespace ServisTakip.Business.Handlers.Companies.Queries
{
    public class GetCompanyQuery : IRequest<ResponseMessage<CompanyDto>>
    {
        public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, ResponseMessage<CompanyDto>>
        {
            public async Task<ResponseMessage<CompanyDto>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
            {
                var companyRepo = ServiceTool.ServiceProvider.GetService<ICompanyRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var company = await companyRepo.GetAsync(s => s.Id == Utils.CompanyId);
                var result = mapper.Map<CompanyDto>(company);
                return ResponseMessage<CompanyDto>.Success(result);
            }
        }
    }
}
