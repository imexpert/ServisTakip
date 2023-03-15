using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class ResultCode : BaseLightEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
