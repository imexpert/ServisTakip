namespace ServisTakip.Entities.DTOs.User
{
    public class UpdateUserDto
    {
        public byte[] Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public string Password { get; set; }
    }
}
