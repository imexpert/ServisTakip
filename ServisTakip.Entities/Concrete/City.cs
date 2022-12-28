using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class City : BaseLightEntity
    {
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
