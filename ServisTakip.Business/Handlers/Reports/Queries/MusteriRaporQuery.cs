using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Reports;
using ServisTakip.Core.Extensions;
using Z.EntityFramework.Plus;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class MusteriRaporQuery : IRequest<PagedResult<List<CustomerReportDto>>>
    {
        public MusteriRaporFilter Model { get; set; }
        public class MusteriRaporQueryHandler : IRequestHandler<MusteriRaporQuery, PagedResult<List<CustomerReportDto>>>
        {
            public async Task<PagedResult<List<CustomerReportDto>>> Handle(MusteriRaporQuery request, CancellationToken cancellationToken)
            {
                var contractRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                return await contractRepo.GetMusteriRaporQuery(request.Model, cancellationToken);
            }
        }
    }
}
