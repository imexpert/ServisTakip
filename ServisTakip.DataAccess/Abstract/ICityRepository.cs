using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface ICityRepository : IEntityRepository<City>
    {
        Task<List<City>> GetCities();
    }
}
