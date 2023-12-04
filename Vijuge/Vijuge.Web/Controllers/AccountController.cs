using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vijuge.Data.Models.DTOs;

namespace Vijuge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        //private readonly SignInManager<UserDTO> _signInManager;
        //private readonly ILogger<UserDTO> _logger;
        //private readonly UserManager<UserDTO> _userManager;

        //public string ReturnUrl { get; set; }

        //public AccountController(SignInManager<UserDTO> signInManager, ILogger<UserDTO> logger, UserManager<UserDTO> userManager)
        //{
        //    this._signInManager = signInManager;
        //    this._logger = logger;
        //    this._userManager = userManager;
        //}

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

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
