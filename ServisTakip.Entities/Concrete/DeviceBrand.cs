using ServisTakip.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Entities.Concrete
{
    public class DeviceBrand : BaseEntity
    {
        public long CompanyId { get; set; }
        public long DeviceTypeId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DeviceType DeviceType { get; set; }
        public ICollection<DeviceModel> DeviceModels { get; set; }
    }
}
