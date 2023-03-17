namespace ServisTakip.Entities.DTOs.Reports
{
    public class SozlesmeBasimRaporFilter
    {
        public long? CustomerId { get; set; }
        public long? SehirId { get; set; }
        public long? IlceId { get; set; }
        public long? SemtId { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public List<string> SozlesmeKodlari { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
    }
}
