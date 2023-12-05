using Vijuge.Data.ViewModels;

namespace Vijuge.Data.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccount();
        Task<bool> EditAccount(UserViewModel userViewModel);
        Task<bool> DeleteAccount(string userId);
        Task<bool> LogIn();
        Task<bool> LogOut();
    }
}
