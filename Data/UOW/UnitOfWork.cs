using Data;
using Domain.Models;
using Interfaces;
using Interfaces.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IEscolaDAO<EscolaModel> _escolas;
        private ITurmaDAO<TurmaModel> _turmas;
        private IUsuarioDAO<UsuarioModel> _usuarios;
        private IAlunoDAO<AlunoModel> _alunos;
        private IGrupoDAO<GrupoModel> _grupos;
        private IFotoDAO<FotoModel> _fotos;
        private IAvaliacaoGrupoDAO<AvaliacaoGrupoModel> _avaliacaoGrupo;
        private IAvaliacaoAlunoDAO<AvaliacaoAlunoModel> _avaliacaoAluno;

        private SareWebContext _dbSSPContext { get; set; }

        public UnitOfWork()
        {
            this.CreateContextDB();
            this._dbSSPContext.Configuration.ProxyCreationEnabled = false;
            this._dbSSPContext.Configuration.LazyLoadingEnabled = true;
            this._dbSSPContext.Configuration.ValidateOnSaveEnabled = false;
        }

        private void CreateContextDB()
        {
            this._dbSSPContext = new SareWebContext();
        }

        public void Commit()
        {
            try
            {
                this._dbSSPContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._dbSSPContext != null)
                {
                    this._dbSSPContext.Dispose();
                    this._dbSSPContext = null;
                }
            }
        }

        public IEscolaDAO<EscolaModel> Escolas
        {
            get
            {
                if (this._escolas == null)
                {
                    this._escolas = new EscolaDAO(this._dbSSPContext);
                }
                return this._escolas;
            }
        }

        public ITurmaDAO<TurmaModel> Turmas
        {
            get
            {
                if(this._turmas == null)
                {
                    this._turmas = new TurmaDAO(this._dbSSPContext);
                }
                return this._turmas;
            }
        }

        public IUsuarioDAO<UsuarioModel> Usuarios
        {
            get
            {
                if (this._usuarios == null)
                {
                    this._usuarios = new UsuarioDAO(this._dbSSPContext);
                }
                return this._usuarios;
            }
        }

        public IAlunoDAO<AlunoModel> Alunos
        {
            get
            {
                if (this._alunos == null)
                {
                    this._alunos = new AlunoDAO(this._dbSSPContext);
                }
                return this._alunos;
            }
        }

        public IGrupoDAO<GrupoModel> Grupos
        {
            get
            {
                if (this._grupos == null)
                {
                    this._grupos = new GrupoDAO(this._dbSSPContext);
                }
                return this._grupos;
            }
        }

        public IFotoDAO<FotoModel> Fotos
        {
            get
            {
                if (this._fotos == null)
                {
                    this._fotos = new FotoDAO(this._dbSSPContext);
                }
                return this._fotos;
            }
        }

        public IAvaliacaoGrupoDAO<AvaliacaoGrupoModel> AvaliacoesGrupo
        {
            get
            {
                if (this._avaliacaoGrupo == null)
                {
                    this._avaliacaoGrupo = new AvaliacaoGrupoDAO(this._dbSSPContext);
                }
                return this._avaliacaoGrupo;
            }
        }

        public IAvaliacaoAlunoDAO<AvaliacaoAlunoModel> AvaliacoesAluno
        {
            get
            {
                if (this._avaliacaoAluno == null)
                {
                    this._avaliacaoAluno = new AvaliacaoAlunoDAO(this._dbSSPContext);
                }
                return this._avaliacaoAluno;
            }
        }

    }
}
