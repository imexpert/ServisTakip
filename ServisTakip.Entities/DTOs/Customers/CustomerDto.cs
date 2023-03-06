using ServisTakip.Entities.DTOs.Sectors;

namespace ServisTakip.Entities.DTOs.Customers
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long SectorId { get; set; }
        public string Title { get; set; }
        public byte[] Logo { get; set; }
        public bool Status { get; set; }
        public SectorDto Sector { get; set; }
    }
}
