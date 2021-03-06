using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Entity
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        public string CourseID { get; set; }
        public string RoleID { get; set; }
        public virtual Course Course { get; set; }
        public virtual Role Role { get; set; }
    }
}
