namespace ServisTakip.Entities.DTOs.DeviceServices
{
    public class CreateBakimFormuDto
    {
        public long DeviceId { get; set; }
        public long? UserId { get; set; }
        public DateTime? UserAssignDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? FailureDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public string ServiceBootCode { get; set; }
        public string BootDescription { get; set; }
        public string ServiceResultCode { get; set; }
        public string CancelDescription { get; set; }
        public string ResultDescription { get; set; }
        public string DetectionCode { get; set; }
        public string DetectionDescription { get; set; }
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
        public int? BlackCount { get; set; }
        public int? BlueCount { get; set; }
        public int? RedCount { get; set; }
        public int? YellowCount { get; set; }
    }
}
