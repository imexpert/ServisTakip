using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public long CompanyId { get; set; }
        public long SectorId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public Sector Sector { get; set; }
        public Company Company { get; set; }
    }
}
