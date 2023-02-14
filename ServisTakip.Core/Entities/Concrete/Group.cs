namespace ServisTakip.Core.Entities.Concrete
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
