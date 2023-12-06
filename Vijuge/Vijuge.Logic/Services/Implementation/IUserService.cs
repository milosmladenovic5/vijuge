using Vijuge.Logic.ViewModels;

namespace Vijuge.Logic.Services.Implementation
{
    public interface IUserService
    {
        Task<bool> Register(UserViewModel userVM);

        Task<bool> Login(LoginViewModel userVM);

        Task Logout();
    }
}
