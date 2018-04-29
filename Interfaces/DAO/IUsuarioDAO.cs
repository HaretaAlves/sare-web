using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DAO
{
    public interface IUsuarioDAO<T> : IRepository<T> where T : class
    {
    }
}
