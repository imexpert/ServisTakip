namespace ServisTakip.Entities.DTOs.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Fullname => Firstname + " " + Lastname;
    }
}
