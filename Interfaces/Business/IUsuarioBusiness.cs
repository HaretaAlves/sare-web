using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface IUsuarioBusiness : IBusinessBase<UsuarioModel>
    {
        IQueryable<UsuarioModel> ListAllByNome(string nome);
    }
}
