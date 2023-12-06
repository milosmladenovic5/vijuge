using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Models.DTOs;
using Vijuge.Data.Repositories.Interface;
using Vijuge.Logic.Services.Implementation;
using Vijuge.Logic.ViewModels;

namespace Vijuge.Logic.Services.Interface
{
    public class UserService : IUserService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UserService (IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<bool> Login(LoginViewModel userVM)
        {
            var userDTO = _mapper.Map<UserDTO>(userVM);
            return await _accountRepository.LogIn(userDTO);
        }

        public Task Logout()
        {
            return _accountRepository.LogOut();
        }

        public Task<bool> Register(UserViewModel userVM)
        {
            var userDTO = new UserDTO() { UserName = userVM.UserName, Email = userVM.Email };

            return _accountRepository.CreateAccount(userDTO);

        }
    }
}
