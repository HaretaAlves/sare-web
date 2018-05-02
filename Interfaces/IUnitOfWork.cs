using Domain.Models;
using Interfaces.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IEscolaDAO<EscolaModel> Escolas { get; }
        ITurmaDAO<TurmaModel> Turmas { get; }
        IUsuarioDAO<UsuarioModel> Usuarios { get; }
        IAlunoDAO<AlunoModel> Alunos { get;  }
        IGrupoDAO<GrupoModel> Grupos { get; }
    }
}
