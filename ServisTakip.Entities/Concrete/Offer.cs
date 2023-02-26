using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Offer : BaseEntity
    {
        public long DeviceServiceId { get; set; }
        public long OfferSubjectCodeId { get; set; }
        public string OfferSendEmail { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string AuthorizeFullname { get; set; }
        public string AuthorizeMail { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string OfferCompanyTitle { get; set; }
        public string OfferAuthorizeFullname { get; set; }
        public string OfferPhone { get; set; }
        public DateTime? OfferDate { get; set; }
        public int OfferStatus { get; set; }
        public int DiscountRate { get; set; }
        public DeviceService DeviceService { get; set; }
    }
}
