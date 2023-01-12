using ServisTakip.Entities.DTOs.DeviceBrands;

namespace ServisTakip.Entities.DTOs.DeviceTypes
{
    public class DeviceTypeDto
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<DeviceBrandDto> DeviceBrands { get; set; }
    }
}
