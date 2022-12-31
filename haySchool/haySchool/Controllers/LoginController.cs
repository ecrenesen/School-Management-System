using Microsoft.AspNetCore.Mvc;

namespace haySchool.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
