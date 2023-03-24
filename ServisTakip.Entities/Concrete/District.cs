using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class District : BaseLightEntity
    {
        public long CityId { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
