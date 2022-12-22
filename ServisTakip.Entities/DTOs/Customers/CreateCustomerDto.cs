using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Entities.DTOs.Customers
{
    public class CreateCustomerDto
    {
        public long SectorId { get; set; }
        public string Title { get; set; }
    }
}
