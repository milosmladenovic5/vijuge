using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Models.DTOs;
using Vijuge.Logic.ViewModels;

namespace Vijuge.Logic
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserModel, UserDTO>();
            CreateMap<LoginModel, UserDTO>();
        }
    }
}
