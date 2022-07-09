using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_And_UnitOfWork.Models.ViewModel
{
    public class ResetPasswordModel
    {
        public string Code { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
