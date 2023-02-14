using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class DeviceModel : BaseEntity
    {
        public long CompanyId { get; set; }
        public long DeviceBrandId { get; set; }
        public string Name { get; set; }
        public string PaperType { get; set; }
        public string ColorType { get; set; }
        public bool? IsScannerExist { get; set; }
        public bool Status { get; set; }
        public DeviceBrand DeviceBrand { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
