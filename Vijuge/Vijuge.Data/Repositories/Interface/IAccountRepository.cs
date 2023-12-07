

using Vijuge.Data.Models.DTOs;

namespace Vijuge.Data.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccount(UserDTO user);
        Task<bool> EditAccount(UserDTO user);
        Task<bool> DeleteAccount(string userId);
        Task<bool> LogIn(UserDTO user);
        Task LogOut();

        IEnumerable<UserDTO> GetAllAccounts();
        Task<UserDTO> GetAccountById();
    }
}
