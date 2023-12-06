using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;
using Vijuge.Data.Models.DTOs;
using Vijuge.Data.Repositories.Interface;

namespace Vijuge.Data.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<UserDTO> _userManager;
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly VijugeDbContext _context;
        private readonly ILogger<UserDTO> _logger;

        public AccountRepository(UserManager<UserDTO> userManager, VijugeDbContext context, ILogger<UserDTO> logger, SignInManager<UserDTO> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateAccount(UserDTO user) // <=> Register
        {
            var result = await _userManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                _logger.LogInformation("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }
            return false;
        }

        public async Task<bool> EditAccount(UserDTO user)
        {
            var userDto = await _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefaultAsync();
            if (user != null)
            {
                userDto.UserName = user.UserName;
                userDto.Email = user.Email;
                userDto.Active = user.Active;
                userDto.Password = user.Password;
            }
            return true;
        }

        public async Task<bool> DeleteAccount(string userId)
        {
            var user = await _userManager.FindByNameAsync(userId);
            if (user != null)
            {
                user.Active = false;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> LogIn(UserDTO userDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(userDTO.UserName,
               userDTO.Password, false, false);

            return result.Succeeded;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
