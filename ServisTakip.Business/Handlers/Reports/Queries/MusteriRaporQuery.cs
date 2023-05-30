using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class MusteriRaporQuery : IRequest<PagedResult<List<CustomerReportDto>>>
    {
        public MusteriRaporFilter Model { get; set; }
        public class MusteriRaporQueryHandler : IRequestHandler<MusteriRaporQuery, PagedResult<List<CustomerReportDto>>>
        {
            public async Task<PagedResult<List<CustomerReportDto>>> Handle(MusteriRaporQuery request, CancellationToken cancellationToken)
            {
                return await Tools.CustomerRepository.GetMusteriRaporQuery(request.Model, cancellationToken);
            }
        }
    }
}
