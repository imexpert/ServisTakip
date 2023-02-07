using ServisTakip.Entities.DTOs.DeviceBrands;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Entities.DTOs.DeviceModels
{
    public class DeviceModelDto
    {
        public long CompanyId { get; set; }
        public long DeviceBrandId { get; set; }
        public string Name { get; set; }
        public string PaperType { get; set; }
        public string ColorType { get; set; }
        public bool? IsScannerExist { get; set; }
        public bool Status { get; set; }
        public DeviceBrandDto DeviceBrand { get; set; }
        public List<DeviceDto> Devices { get; set; }
    }
}
