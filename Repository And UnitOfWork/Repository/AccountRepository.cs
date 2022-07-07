using FirstProject_MVC.Models.Data;
using FirstProject_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Repository
{
    public class AccountRepository: RepositoryBase<Account>
    {
        public AccountRepository(Entities context): base(context)
        {

        }
    }
}
