namespace ServisTakip.Entities.DTOs.Addresses
{
    public class UpdateAddressDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long DistrictId { get; set; }
        public string AddressTitle { get; set; }
        public string QuerterName { get; set; }
        public string AccountCode { get; set; }
        public string RegionCode { get; set; }
        public string NetAddress { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedWorkPhone { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
    }
}
