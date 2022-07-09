using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Data;
using WebAPI.Models.Entity;

namespace WebAPI.Repository
{
    public interface IUserRepository: IRepository<User>
    {

    }
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(DemoDbContext context): base(context)
        {

        }

    }
}
