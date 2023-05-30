using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Company : BaseEntity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string AuthorizeFullname { get; set; }
        public string AuthorizeMail { get; set; }
        public int NumberOfUser { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool Status { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
