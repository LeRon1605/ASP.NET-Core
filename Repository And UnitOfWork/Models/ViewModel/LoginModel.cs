using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_And_UnitOfWork.Models.ViewModel
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}
