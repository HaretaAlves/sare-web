using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DAO
{
    public interface IFotoDAO<T> : IRepository<T> where T : class
    {
        FotoModel GetByAlunoId(int alunoId);
    }
}
