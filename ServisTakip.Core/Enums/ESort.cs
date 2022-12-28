using System.ComponentModel.DataAnnotations;

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
