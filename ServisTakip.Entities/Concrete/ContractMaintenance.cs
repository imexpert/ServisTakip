using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class ContractMaintenance : BaseEntity
    {
        public long ContractId { get; set; }
        public long? DeviceServiceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public Contract Contract { get; set; }
        public DeviceService DeviceService { get; set; }
    }
}
