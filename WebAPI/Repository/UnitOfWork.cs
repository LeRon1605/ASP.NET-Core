using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Data;

namespace WebAPI.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
    }
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DemoDbContext _context;
        public UnitOfWork(DemoDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
