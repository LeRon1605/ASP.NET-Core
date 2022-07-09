using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Data;
using WebAPI.Models.Entity;

namespace WebAPI.Repository
{
    public interface ICourseRepository: IRepository<Course>
    {

    }
    public class CourseRepository: BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DemoDbContext context): base(context)
        {

        }
    }
}
