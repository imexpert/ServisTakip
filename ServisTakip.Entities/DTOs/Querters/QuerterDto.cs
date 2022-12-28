using ServisTakip.Entities.DTOs.Districts;

namespace ServisTakip.Entities.DTOs.Querters
{
    public class QuerterDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DistrictDto District { get; set; }
    }
}
