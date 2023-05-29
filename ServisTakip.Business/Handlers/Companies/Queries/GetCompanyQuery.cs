using ServisTakip.Entities.DTOs.Companies;

namespace ServisTakip.Business.Handlers.Companies.Queries
{
    public class GetCompanyQuery : IRequest<ResponseMessage<CompanyDto>>
    {
        public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, ResponseMessage<CompanyDto>>
        {
            public async Task<ResponseMessage<CompanyDto>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
            {
                var company = await Tools.CompanyRepository.GetAsync(s => s.Id == Utils.CompanyId);
                var result = Tools.Mapper.Map<CompanyDto>(company);
                return ResponseMessage<CompanyDto>.Success(result);
            }
        }
    }
}
