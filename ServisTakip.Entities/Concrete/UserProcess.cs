using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class UserProcess : BaseEntity
    {
        public long UserId { get; set; }
        public long? DeviceServiceId { get; set; }
        public long? DeviceId { get; set; }
        public long? CustomerId { get; set; }
    }
}
