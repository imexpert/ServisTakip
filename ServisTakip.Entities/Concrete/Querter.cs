using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Querter : BaseLightEntity
    {
        public long DistrictId { get; set; }
        public string Name { get; set; }
        public string RegionCode { get; set; }
        public District District { get; set; }
    }
}
