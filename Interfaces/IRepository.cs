using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> List();

        T GetById(int id);

        T Insert(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
