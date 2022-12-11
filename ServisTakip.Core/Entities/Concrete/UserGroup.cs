using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Core.Entities.Concrete
{
    public class UserGroup : BaseEntity
    {
        public long GroupId { get; set; }
        public long UserId { get; set; }
    }
}
