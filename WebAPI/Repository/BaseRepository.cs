using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Models.Data;

namespace WebAPI.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DemoDbContext _context;
        public BaseRepository(DemoDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string ID)
        {
            T entity = _context.Set<T>().Find(ID);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }    
        }

        public IEnumerable<T> find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> findAll()
        {
            return _context.Set<T>();
        }

        public T findByID(string ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
            _context.SaveChanges();
        }
    }
}
