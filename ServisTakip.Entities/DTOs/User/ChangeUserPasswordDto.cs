namespace ServisTakip.Entities.DTOs.User
{
    public class ChangeUserPasswordDto
    {
        public long Id { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
