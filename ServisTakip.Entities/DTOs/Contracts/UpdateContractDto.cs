namespace ServisTakip.Entities.DTOs.Contracts
{
    public class UpdateContractDto
    {
        public long Id { get; set; }
        public long DeviceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractCode { get; set; }
        public int MaintenancePeriod { get; set; }
        public decimal? Price { get; set; }
        public string CurrencyType { get; set; }
        public bool Status { get; set; }
    }
}