using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface IAvaliacaoGrupoBusiness : IBusinessBase<AvaliacaoGrupoModel>
    {
        IQueryable<AvaliacaoGrupoModel> ListAllByNome(string nome);

        IQueryable<AvaliacaoGrupoModel> ListAllByDate(DateTime date);
    }
}
