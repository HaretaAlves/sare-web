using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface ITurmaBusiness : IBusinessBase<TurmaModel>
    {
        IQueryable<TurmaModel> ListAllByNome(string nome);

        IQueryable<TurmaModel> ListByEscolaID(int escolaID);

        List<TurmaModel> AddList(List<TurmaModel> list);
        
    }
}
