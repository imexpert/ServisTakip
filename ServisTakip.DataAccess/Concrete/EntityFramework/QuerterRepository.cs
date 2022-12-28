using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class QuerterRepository : EntityRepositoryBase<Querter, ProjectDbContext>, IQuerterRepository
    {
        public QuerterRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
