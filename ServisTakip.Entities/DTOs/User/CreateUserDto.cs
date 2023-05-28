using Microsoft.AspNetCore.Http;

namespace ServisTakip.Entities.DTOs.User
{
    public class CreateUserDto
    {
        public byte[] Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public List<string> Groups { get; set; }
    }
}
