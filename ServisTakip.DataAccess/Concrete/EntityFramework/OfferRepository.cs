using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class OfferRepository : EntityRepositoryBase<Offer, ProjectDbContext>, IOfferRepository
    {
        public OfferRepository(ProjectDbContext context) 
            : base(context)
        {
        }
    }
}
