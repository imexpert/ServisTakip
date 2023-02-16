using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Address: BaseEntity
    {
        public long CustomerId { get; set; }
        public long QuarterId { get; set; }
        public string AddressTitle { get; set; }
        public string AccountCode { get; set; }
        public string NetAddress { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public bool Status { get; set; }
        public ICollection<Device> Devices { get; set; }
        public Customer Customer { get; set; }
        public Querter Querter { get; set; }
    }
}
