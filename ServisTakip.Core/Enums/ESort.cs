using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Core.Enums
{
    public enum ESort
    {
        [Display(Name = "OrderBy")]
        ASC = 1,

        [Display(Name = "OrderByDescending")]
        DESC = 2
    }
}
