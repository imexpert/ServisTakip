using Microsoft.VisualBasic;
using ServisTakip.Entities.DTOs.UserGroups;
using System.Diagnostics.Metrics;
using System.Linq;

namespace ServisTakip.Entities.DTOs.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public byte[] Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public string Token { get; set; }
        public bool Status { get; set; }
        public string Fullname => Firstname + " " + Lastname;
        public bool IsAdmin { get; set; }
        public DateTime LastLogin { get; set; }
        public string LastLoginString => LastLogin > DateTime.MinValue ? LastLogin.ToString("dd/MM/yyyy HH:mm:ss") : "-";
        // public string Groups => string.Join(" , ", this.UserGroups != null ? this.UserGroups?.Select(s => s.Group.GroupName).ToList<string>(): "");
        public string Groups
        {
            set { }
            get {
                string result = "";
                foreach (var group in UserGroups)
                {
                    if (group.Group != null)
                    {
                        result += group.Group.GroupName + ",";
                    }
                }

                result = result.Length > 0 ? result.Remove(result.Length - 1, 1) : "";

                return result;
            }
        }
        public List<UserGroupDto> UserGroups = new List<UserGroupDto>();
    }
}
