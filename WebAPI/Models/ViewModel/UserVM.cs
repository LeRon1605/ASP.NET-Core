using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.ViewModel
{
    public class UserVM
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
        public string CourseID { get; set; }
        public string Course { get; set; }
    }
}
