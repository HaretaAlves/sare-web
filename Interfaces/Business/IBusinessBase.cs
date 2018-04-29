using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface IBusinessBase<T> : IDisposable
    {
        IQueryable<T> ListAll();

        T GetById(int id);

        bool Update(T entity);

        T Add(T entity);

        bool Delete(T entity);
    }
}
