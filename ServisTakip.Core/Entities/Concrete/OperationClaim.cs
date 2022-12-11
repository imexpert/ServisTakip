using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
    }
}
