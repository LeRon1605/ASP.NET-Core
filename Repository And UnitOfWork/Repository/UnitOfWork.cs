using FirstProject_MVC.Models.Data;
using FirstProject_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Repository
{
    public class UnitOfWork
    {
        public UserRepository UserRepository { get; set; }
        public AccountRepository AccountRepository { get; set; }
        public Entities context { get; set; }
        public UnitOfWork(Entities _context)
        {
            context = _context;
            UserRepository = new UserRepository(context);
            AccountRepository = new AccountRepository(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

    }
}
