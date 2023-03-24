using ServisTakip.Entities.DTOs.DeviceModels;
using ServisTakip.Entities.DTOs.DeviceTypes;

namespace ServisTakip.Entities.DTOs.DeviceBrands
{
    public class DeviceBrandDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long DeviceTypeId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DeviceTypeDto DeviceType { get; set; }
        public List<DeviceModelDto> DeviceModels { get; set; }
    }
}
