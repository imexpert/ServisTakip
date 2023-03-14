namespace ServisTakip.Entities.DTOs.Devices
{
    public class CreateDeviceDto
    {
        public long Id { get; set; }
        public long AddressId { get; set; }
        public long DeviceModelId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AssemblyDate { get; set; }
        public string Description { get; set; }
        public int MaintenancePeriod { get; set; }
        public bool Status { get; set; }
    }
}
