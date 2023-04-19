using ServisTakip.Entities.DTOs.Groups;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Entities.DTOs.UserGroups
{
    public class UserGroupDto
    {
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public GroupDto Group { get; set; }
        public UserDto User { get; set; }
    }
}
