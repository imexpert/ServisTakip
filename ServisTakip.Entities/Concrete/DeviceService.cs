using ServisTakip.Core.Entities;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.Entities.Concrete
{
    public class DeviceService : BaseEntity
    {
        public long? LinkedDeviceServiceId { get; set; }
        public long DeviceId { get; set; }
        public long? UserId { get; set; }
        public DateTime? UserAssignDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? FailureDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public string ServiceBootCode { get; set; }
        public string BootDescription { get; set; }
        public string DetectionCode { get; set; }
        public string DetectionDescription { get; set; }
        public string ServiceResultCode { get; set; }
        public string CancelDescription { get; set; }
        public string ResultDescription { get; set; }
        public int? WBCount { get; set; }
        public int? ColorCount { get; set; }
        public bool? Dr { get; set; }
        public bool? Dv { get; set; }
        public bool? Bc { get; set; }
        public bool? Fs { get; set; }
        public bool? Pa { get; set; }
        public bool? Bk { get; set; }
        public bool? Ak { get; set; }
        public byte? TonerType { get; set; }
        public int? BlackCount{ get; set; }
        public int? BlueCount{ get; set; }
        public int? RedCount{ get; set; }
        public int? YellowCount{ get; set; }
        public int StatusCode { get; set; }
        public User User { get; set; }
        public Device Device { get; set; }
        public DeviceService LinkedDeviceService { get; set; }
        public ICollection<DeviceService> DeviceServices { get; set; }
        public ICollection<ContractMaintenance> ContractMaintenances { get; set; }
    }
}
