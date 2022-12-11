using Microsoft.AspNetCore.Mvc;

namespace ServisTakip.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
