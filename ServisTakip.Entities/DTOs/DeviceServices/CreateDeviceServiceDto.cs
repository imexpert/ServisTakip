﻿namespace ServisTakip.Entities.DTOs.DeviceServices
{
    public class CreateDeviceServiceDto
    {
        public long DeviceId { get; set; }
        public string FailureDate { get; set; }
        public string ServiceBootCode { get; set; }
        public string BootDescription { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public long? UserId { get; set; }
        public string? UserAssignDate { get; set; }
    }
}
