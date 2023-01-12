using ServisTakip.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Entities.Concrete
{
    public class Address: BaseEntity
    {
        public long CustomerId { get; set; }
        public long QuarterId { get; set; }
        public string AccountCode { get; set; }
        public string NetAddress { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
