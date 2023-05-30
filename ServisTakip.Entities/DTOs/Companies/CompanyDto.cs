using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Entities.DTOs.Companies
{
    public class CompanyDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string AuthorizeFullname { get; set; }
        public string AuthorizeMail { get; set; }
        public int NumberOfUser { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool Status { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}
