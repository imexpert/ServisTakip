using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.DeviceModels;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Entities.DTOs.Devices
{
    public class DeviceDto
    {
        public long AddressId { get; set; }
        public long DeviceModelId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AssemblyDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public AddressDto Address { get; set; }
        public DeviceModelDto DeviceModel { get; set; }
        public List<DeviceServiceDto> DeviceServices { get; set; }
    }
}
