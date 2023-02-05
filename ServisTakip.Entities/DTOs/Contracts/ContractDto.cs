using ServisTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Entities.DTOs.Contracts
{
    public class ContractDto
    {
        public long DeviceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractCode { get; set; }
        public bool Status { get; set; }
        public DeviceDto Device { get; set; }
    }
}
