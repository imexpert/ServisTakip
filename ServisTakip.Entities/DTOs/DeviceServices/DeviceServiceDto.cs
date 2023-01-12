using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Entities.DTOs.DeviceServices
{
    public class DeviceServiceDto
    {
        public long LinkedDeviceServiceId { get; set; }
        public long DeviceId { get; set; }
        public long UserId { get; set; }
        public DateTime UserAssignDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime FailureDate { get; set; }
        public string ServiceBootCode { get; set; }
        public string BootDescription { get; set; }
        public string ServiceResultCode { get; set; }
        public string ResultDescription { get; set; }
        public int WBCount { get; set; }
        public int ColorCount { get; set; }
        public string StatusCode { get; set; }
        public DeviceDto Device { get; set; }
        public DeviceServiceDto LinkedDeviceService { get; set; }
        public ICollection<DeviceServiceDto> DeviceServices { get; set; }
    }
}
