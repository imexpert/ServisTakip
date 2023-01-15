using ServisTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Entities.DTOs.Sectors;
using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Entities.DTOs.Customers
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long SectorId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public SectorDto Sector { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
