using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DAO
{
    public interface ITurmaDAO<T> : IRepository<T> where T : class
    {
        IQueryable<TurmaModel> ListByEscolaID(int escolaID);

        TurmaModel GetByNome(string nome);
    }
}
