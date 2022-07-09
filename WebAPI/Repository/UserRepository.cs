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
    public interface IUserRepository: IRepository<User>
    {
        public PagingList<UserVM> GetPage(int page, int pageSize, string keyword);
    }
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(DemoDbContext context): base(context)
        {

        }

        public PagingList<UserVM> GetPage(int page, int pageSize, string keyword)
        {
            List<UserVM> users = _context.Users.AsNoTracking()
                                             .Where(user => user.Name.Contains(keyword))
                                             .Skip((page - 1) * pageSize).Take(pageSize)
                                             .Select(user => new UserVM
                                             {
                                                 ID = user.ID,
                                                 Name = user.Name,
                                                 CourseID = user.CourseID,
                                                 Course = user.Course.Name,
                                                 Address = user.Address,
                                                 Email = user.Email
                                             }).ToList();
            return new PagingList<UserVM>()
            {
                page = page,
                totalPage = (int)Math.Ceiling(_context.Users.Count() / (double)pageSize),
                data = users
            };
        }
    }
}
