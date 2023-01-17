using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.Querters;

namespace ServisTakip.Entities.DTOs.Addresses
{
    public class CreateAddressDto
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
    }
}
