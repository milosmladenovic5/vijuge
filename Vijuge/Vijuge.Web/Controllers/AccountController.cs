using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Vijuge.Data.Models.DTOs;
using Vijuge.Logic.Services.Implementation;
using Vijuge.Logic.ViewModels;

namespace Vijuge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public string ReturnUrl { get; set; }

        public AccountController(IUserService userService, ILogger<AccountController> logger)
        {
            this._userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userReg, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Home");

            if (ModelState.IsValid)
            {
                var result = await _userService.Register(userReg);

                return StatusCode(result ? 200 : 500);
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            ReturnUrl ??= Url.Content("~/Home");

            if (ModelState.IsValid)
            {
                var loginResult = await _userService.Login(model);

                if (loginResult)
                {
                    return StatusCode(200, ReturnUrl);
                }
                else
                {
                    return StatusCode(500, "Home");
                }
            }
            ModelState.AddModelError("Home", "Invalid login attempt");
            return StatusCode(404, "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            _logger.LogInformation("User logged out.");

            return StatusCode(200, "Home");
        }

        public async Task<IActionResult> Edit(UserModel userReg)
        {
            return StatusCode(200);
        }

        public async Task<IActionResult> Delete()
        {
            return StatusCode(200);
        }
    }
}
