using Microsoft.AspNetCore.Identity;
using Vijuge.Data;
using Vijuge.Data.Models.DTOs;
using Vijuge.Data.Repositories.Interface;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Vijuge.Data.ViewModels;

namespace Vijuge.Data.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<UserDTO> _userManager;
        private readonly VijugeDbContext _context;

        public AccountRepository(UserManager<UserDTO> userManager, VijugeDbContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }

        public async Task<bool> CreateAccount() // <=> Register
        {
            return true;
        }

        public async Task<bool> EditAccount(UserViewModel user)
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

        public async Task<bool> LogIn()
        {
            return true;
        }

        public async Task<bool> LogOut()
        {
            return true;
        }
    }
}
