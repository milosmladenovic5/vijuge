using Microsoft.AspNetCore.Mvc;

namespace Vijuge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
