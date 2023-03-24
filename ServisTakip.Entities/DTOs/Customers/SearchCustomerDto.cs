namespace ServisTakip.Entities.DTOs.Customers
{
    public class SearchCustomerDto
    {
        public string RowId { get; set; }
        public long Id { get; set; }
        public long AddressId { get; set; }
        public long DeviceId { get; set; }
        public string Title { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string District { get; set; }
        public string Department { get; set; }
    }
}
