namespace ServisTakip.Entities.DTOs.Customers
{
    public class CustomerReportDto
    {
        public long CustomerId { get; set; }
        public string Unvan { get; set; }
        public long AddressId { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Semt { get; set; }
        public long DeviceId { get; set; }
        public string Tip { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string CihazSeriNo { get; set; }
        public string MontajTarihi { get; set; }
        public string SozlesmeKodu { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
    }
}
