using ServisTakip.Entities.DTOs.Sectors;
using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Entities.DTOs.Customers
{
    public class SearchCustomerDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Sector { get; set; }
    }
}
