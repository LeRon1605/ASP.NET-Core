using FirstProject_MVC.Models.Data;
using FirstProject_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Repository
{
    public interface IUserRepository: IRepository<User>
    {

    }
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(Entities context): base(context)
        {

        }   
    }
}
