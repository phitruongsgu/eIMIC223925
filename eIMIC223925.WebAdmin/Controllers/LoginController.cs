using Microsoft.AspNetCore.Mvc;

namespace eIMIC223925.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
