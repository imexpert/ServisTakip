namespace ServisTakip.Entities.DTOs.Customers
{
    public class CreateCustomerDto
    {
        public long SectorId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
