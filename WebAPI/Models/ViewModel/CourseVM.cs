using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.ViewModel
{
    public class CourseVM
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Tên khóa học không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tín chỉ không được để trống")]
        [Range(0, 10)]
        public int Credit { get; set; }
    }
}
