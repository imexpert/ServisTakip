namespace ServisTakip.Entities.DTOs.Customers
{
    public class UpdateCustomerDto
    {
        public long Id { get; set; }
        public long SectorId { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
