using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Contract : BaseEntity
    {
        public long DeviceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractCode { get; set; }
        public int MaintenancePeriod { get; set; }
        public bool Status { get; set; }
        public Device Device { get; set; }
        public ICollection<ContractMaintenance> ContractMaintenances { get; set; }
    }
}
