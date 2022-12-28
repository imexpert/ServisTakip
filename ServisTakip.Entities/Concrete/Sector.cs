using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Sector : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
