using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Entities.DTOs.DeviceServices
{
    public class DeviceServiceDto
    {
        public long Id { get; set; }
        public long? LinkedDeviceServiceId { get; set; }
        public long DeviceId { get; set; }
        public long? UserId { get; set; }
        public DateTime? UserAssignDate { get; set; }
        public string UserAssignDateString => UserAssignDate?.ToString("dd/MM/yyyy HH:mm:ss");
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? FailureDate { get; set; }
        public string FailureDateString => FailureDate?.ToString("dd/MM/yyyy HH:mm:ss");
        public DateTime? ResultDate { get; set; }
        public string ResultDateString => ResultDate?.ToString("dd/MM/yyyy HH:mm:ss");
        public string ServiceBootCode { get; set; }
        public string BootDescription { get; set; }
        public string ServiceResultCode { get; set; }
        public string ResultDescription { get; set; }
        public int? WBCount { get; set; }
        public int? ColorCount { get; set; }
        public byte? Dr { get; set; }
        public byte? Dv { get; set; }
        public byte? Bc { get; set; }
        public byte? Fs { get; set; }
        public byte? Pa { get; set; }
        public byte? Bk { get; set; }
        public byte? Ak { get; set; }
        public int StatusCode { get; set; }
        public UserDto User { get; set; }
        public DeviceDto Device { get; set; }
        public DeviceServiceDto LinkedDeviceService { get; set; }
        public ICollection<DeviceServiceDto> DeviceServices { get; set; }
    }
}
