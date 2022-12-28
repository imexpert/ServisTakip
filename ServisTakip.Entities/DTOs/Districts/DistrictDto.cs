using ServisTakip.Entities.DTOs.Cities;
using ServisTakip.Entities.DTOs.Querters;

namespace ServisTakip.Entities.DTOs.Districts
{
    public class DistrictDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CityDto City { get; set; }
        public List<QuerterDto> Querters { get; set; }
    }
}
