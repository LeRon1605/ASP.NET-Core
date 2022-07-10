using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Data;
using WebAPI.Models.Entity;
using WebAPI.Models.ViewModel;

namespace WebAPI.Repository
{
    public interface ICourseRepository: IRepository<Course>
    {
        IEnumerable<UserVM> GetUserOfCourse(string ID);
    }
    public class CourseRepository: BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DemoDbContext context): base(context)
        {

        }

        public IEnumerable<UserVM> GetUserOfCourse(string ID)
        {
            return _context.Users.AsNoTracking().Where(user => user.CourseID == ID).Select(user => new UserVM
            {
                ID = user.ID,
                Name = user.Name,
                CourseID = user.CourseID,
                Course = user.Course.Name,
                Address = user.Address,
                Email = user.Email
            });
        }
    }
}
