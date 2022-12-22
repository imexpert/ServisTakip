using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.DataAccess;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
    }
}
