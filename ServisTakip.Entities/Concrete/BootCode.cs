using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class BootCode : BaseLightEntity
    {
        public long CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
