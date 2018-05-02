using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface IGrupoBusiness : IBusinessBase<GrupoModel>
    {
        IQueryable<GrupoModel> ListAllByNome(string nome);
    }
}
