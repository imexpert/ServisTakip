using ServisTakip.Entities.DTOs.Districts;

namespace ServisTakip.Entities.DTOs.Cities
{
    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DistrictDto> Districts { get; set; }
    }
}
