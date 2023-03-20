using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.Querters;

namespace ServisTakip.Entities.DTOs.Addresses
{
    public class AddressDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long QuarterId { get; set; }
        public string AddressTitle { get; set; }
        public string AccountCode { get; set; }
        public string NetAddress { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedWorkPhone { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public bool Status { get; set; }
        public CustomerDto Customer { get; set; }
        public List<DeviceDto> Devices { get; set; }
        public QuerterDto Querter { get; set; }

    }
}
