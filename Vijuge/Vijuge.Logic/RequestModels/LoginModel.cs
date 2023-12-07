using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vijuge.Logic.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public LoginModel()
        {
            ReturnUrl = "";
        }
    }
}
