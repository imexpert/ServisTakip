namespace ServisTakip.Entities.DTOs.DeviceServiceParts
{
    public class CreateDeviceServicePartDto
    {
        public long Id { get; set; }
        public long DeviceServiceId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int NumberOfProduct { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
    }
}
