using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Device : BaseEntity
    {
        public long AddressId { get; set; }
        public long DeviceModelId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AssemblyDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Address Address { get; set; }
        public DeviceModel DeviceModel { get; set; }
        public ICollection<DeviceService> DeviceServices { get; set; }
    }
}
