namespace ServisTakip.Entities.DTOs.Addresses
{
    public class UpdateAddressDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long QuarterId { get; set; }
        public string AddressTitle { get; set; }
        public string AccountCode { get; set; }
        public string NetAddress { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public string Department { get; set; }
    }
}
