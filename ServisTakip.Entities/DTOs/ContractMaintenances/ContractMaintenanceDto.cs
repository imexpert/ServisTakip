using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Entities.DTOs.Contracts
{
    public class ContractMaintenanceDto
    {
        public long ContractId { get; set; }
        public long DeviceServiceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public ContractDto Contract { get; set; }
        public DeviceServiceDto DeviceService { get; set; }
    }
}
