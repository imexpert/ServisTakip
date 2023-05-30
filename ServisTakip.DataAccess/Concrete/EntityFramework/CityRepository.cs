using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class CityRepository : EntityRepositoryBase<City, ProjectDbContext>, ICityRepository
    {
        readonly ProjectDbContext _context;
        public CityRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<City>> GetCities()
        {
            return await _context.Cities
                .Include(s=>s.Districts)
                .ToListAsync();
        }
    }
}
