using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Entity
{
    public class Course
    {
        [Key]
        public string ID { get; set; }
        [Required(ErrorMessage = "Tên khóa học không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Số tín chỉ không được để trống")]
        public int Credit { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
