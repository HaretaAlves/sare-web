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

        private SareWebContext _dbSSPContext { get; set; }

        public UnitOfWork()
        {
            this.CreateContextDB();
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

    }
}
