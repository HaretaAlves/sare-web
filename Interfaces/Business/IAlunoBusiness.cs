using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface IAlunoBusiness : IBusinessBase<AlunoModel>
    {
        IQueryable<AlunoModel> ListAllByNome(string nome);

        IQueryable<AlunoModel> ListByTurmaID(int turmaID);
    }
}
