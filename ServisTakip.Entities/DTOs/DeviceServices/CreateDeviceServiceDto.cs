using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Entities.DTOs.DeviceServices
{
    public class CreateDeviceServiceDto
    {
        public DateTime FailureDate { get; set; }
        public string ServiceBootCode { get; set; }
        public string BootDescription { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public long? UserId { get; set; }
        public DateTime? UserAssignDate { get; set; }
    }
}
