using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Entities.DTOs.Contracts
{
    public class ContractDto
    {
        public long Id { get; set; }
        public long DeviceId { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateString => StartDate.ToString("dd/MM/yyyy");
        public DateTime EndDate { get; set; }
        public string EndDateString => EndDate.ToString("dd/MM/yyyy");
        public string ContractCode { get; set; }
        public int MaintenancePeriod { get; set; }
        public bool Status { get; set; }
        public DeviceDto Device { get; set; }
    }
}