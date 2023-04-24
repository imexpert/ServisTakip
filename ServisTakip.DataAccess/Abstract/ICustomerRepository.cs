using ServisTakip.Core.DataAccess;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Task<Customer> GetCustomerById(long id);
        Task<List<Customer>> GetCustomerByFilterAsync(string filter, CancellationToken cancellationToken);
        Task<List<Customer>> GetCustomerListAsync(CancellationToken cancellationToken);
        IQueryable<Customer> GetMusteriRaporQuery();

        Task<PagedResult<List<CustomerReportDto>>> GetMusteriRaporQuery(MusteriRaporFilter filter,
            CancellationToken cancellationToken);
    }
}
