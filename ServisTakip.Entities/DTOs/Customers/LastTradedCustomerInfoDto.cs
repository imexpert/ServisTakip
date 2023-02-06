using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Entities.DTOs.Customers
{
    public class LastTradedCustomerInfoDto
    {
        public long CustomerId { get; set; }
        public string CustomerTitle { get; set; }
        public string CustomerSector { get; set; }
        public long DeviceId { get; set; }
        public string AccountCode { get; set; }
        public string RegionCode { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string QuarterName { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public List<ContractDto> Contracts { get; set; }
    }
}
