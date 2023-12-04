namespace Vijuge.Web.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccount();
        Task<bool> EditAccount(string userId);
        Task<bool> DeleteAccount(string userId);
        Task<bool> LogIn();
        Task<bool> LogOut();
    }
}
