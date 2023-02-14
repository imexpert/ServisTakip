namespace ServisTakip.Core.Entities.Concrete
{
    public class UserGroup : BaseEntity
    {
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }
}
