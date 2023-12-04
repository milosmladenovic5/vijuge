using Microsoft.AspNetCore.Identity;
using Vijuge.Data;
using Vijuge.Data.Models.DTOs;
using Vijuge.Web.Repositories.Interface;

namespace Vijuge.Web.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        //private readonly UserManager<UserDTO> _userManager;
        //private readonly VijugeDbContext _context;

        //public AccountRepository(UserManager<UserDTO> userManager, VijugeDbContext context)
        //{
        //    this._userManager = userManager;
        //    this._context = context;
        //}

        public async Task<bool> CreateAccount() // <=> Register
        {
            return true;
        }

        public async Task<bool> EditAccount(string userId)
        {
            return true;
        }

        public async Task<bool> DeleteAccount(string userId)
        {
            //var user = await _userManager.FindByNameAsync(userId);
            //if (user != null)
            //{
            //    user.Active = false;
            //    _context.Users.Update(user);
            //    await _context.SaveChangesAsync();
            //    return true;
            //}
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
