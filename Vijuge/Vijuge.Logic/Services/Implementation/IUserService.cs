using Vijuge.Logic.ViewModels;

namespace Vijuge.Logic.Services.Implementation
{
    public interface IUserService
    {
        Task<bool> Register(UserModel userVM);

        Task<bool> Login(LoginModel userVM);

        Task Logout();
    }
}
