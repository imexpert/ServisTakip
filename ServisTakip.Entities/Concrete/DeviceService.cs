﻿using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class DeviceService : BaseEntity
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
        public Device Device { get; set; }
        public DeviceService LinkedDeviceService { get; set; }
        public ICollection<DeviceService> DeviceServices { get; set; }
    }
}
