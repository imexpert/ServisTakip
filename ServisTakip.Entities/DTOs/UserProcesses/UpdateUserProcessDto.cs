﻿namespace ServisTakip.Entities.DTOs.UserProcesses
{
    public class UpdateUserProcessDto
    {
        public long? DeviceServiceId { get; set; }
        public long? CustomerId { get; set; }
        public long? DeviceId { get; set; }
        public long? AddressId { get; set; }
    }
}
