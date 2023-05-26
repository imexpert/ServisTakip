using Microsoft.AspNetCore.Http;

namespace ServisTakip.Entities.DTOs.User
{
    public class CreateUserModel
    {
        public IFormFile File { get; set; }
        public CreateUserDto UserItem { get; set; }
    }
}
