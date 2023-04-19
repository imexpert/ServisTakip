using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Task<Customer> GetCustomerById(long id);
        Task<List<Customer>> GetCustomerByFilterAsync(string filter, CancellationToken cancellationToken);
        Task<List<Customer>> GetCustomerListAsync(CancellationToken cancellationToken);
        IQueryable<Customer> GetMusteriRaporQuery();
    }
}
