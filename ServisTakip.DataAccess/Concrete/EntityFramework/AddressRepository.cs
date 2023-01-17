using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class AddressRepository : EntityRepositoryBase<Address, ProjectDbContext>, IAddressRepository
    {
        public AddressRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
