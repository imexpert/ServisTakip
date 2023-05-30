using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class CompanyRepository : EntityRepositoryBase<Company, ProjectDbContext>, ICompanyRepository
    {
        ProjectDbContext _context;
        public CompanyRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
