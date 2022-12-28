namespace ServisTakip.Entities.DTOs.User
{
    public class CreateUserDto
    {
        public long CompanyId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
