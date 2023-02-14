using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Task<Customer> GetCustomerById(long id);
        Task<List<Customer>> GetCustomerByFilterAsync(string filter, CancellationToken cancellationToken);
    }
}
