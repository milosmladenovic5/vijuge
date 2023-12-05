using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Vijuge.Data.Models.DTOs;
using Vijuge.Data.ViewModels;

namespace Vijuge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly ILogger<UserDTO> _logger;
        private readonly UserManager<UserDTO> _userManager;

        public string ReturnUrl { get; set; }

        public AccountController(SignInManager<UserDTO> signInManager, ILogger<UserDTO> logger, UserManager<UserDTO> userManager)
        {
            this._signInManager = signInManager;
            this._logger = logger;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userReg, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Home");

            if (ModelState.IsValid)
            {
                var user = new UserDTO() { UserName = userReg.UserName, Email = userReg.Email };

                var result = await _userManager.CreateAsync(user, userReg.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return StatusCode(200, returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            ReturnUrl ??= Url.Content("~/Home");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName,
                   model.Password, false, false);

                if (result.Succeeded)
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
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            return StatusCode(200, "Home");

        }

        public async Task<IActionResult> Edit()
        {
            return StatusCode(200);
        }

        public async Task<IActionResult> Delete()
        {
            return StatusCode(200);
        }
    }
}
