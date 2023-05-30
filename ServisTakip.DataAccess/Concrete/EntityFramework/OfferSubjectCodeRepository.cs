using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class OfferSubjectCodeRepository : EntityRepositoryBase<OfferSubjectCode, ProjectDbContext>, IOfferSubjectCodeRepository
    {
        public OfferSubjectCodeRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
