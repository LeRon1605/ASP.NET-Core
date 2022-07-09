using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Repository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> findAll();
        IEnumerable<T> find(Expression<Func<T, bool>> expression);
        T findByID(string ID);
        void Add(T entity);
        void Delete(string ID);
        void Update(T entity);
    }
}
