using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Entities.DTOs.Reports
{
    public class TechnicianDeviceServiceReportModel
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string NetAddress { get; set; }
        public string Querter { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public long DeviceNo { get; set; }
        public string ContractCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AuthorizeName { get; set; }
        public string Phone { get; set; }
        public string BootDescription { get; set; }
    }
}
