using FirstProject_MVC.Models.Data;
using FirstProject_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Repository
{
    public interface IUnitOfWork
    {
        void Complete();
    }
    public class UnitOfWork: IUnitOfWork
    {
        public Entities context { get; set; }
        public UnitOfWork(Entities _context)
        {
            context = _context;
        }

        public void Complete()
        {
            context.SaveChanges();
        }

    }
}
