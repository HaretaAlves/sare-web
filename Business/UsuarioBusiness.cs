using Data.UOW;
using Domain.Models;
using Interfaces;
using Interfaces.Business;
using Interfaces.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private IUnitOfWork UOW = null;

        public UsuarioBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        public UsuarioModel Add(UsuarioModel entity)
        {
            try
            {
                var usuario = this.UOW.Usuarios.Insert(entity);
                this.UOW.Commit();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(UsuarioModel entity)
        {            
            try
            {
                if(entity.ID > 0)
                {
                    this.UOW.Usuarios.Delete(entity.ID);
                    this.UOW.Commit();
                    return true;
                }

                return false;
            }            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioModel GetById(int id)
        {
            try
            {
                var usuario = this.UOW.Usuarios.GetById(id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<UsuarioModel> ListAll()
        {
            try
            {
                var usuarios = this.UOW.Usuarios.List();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<UsuarioModel> ListAllByNome(string nome)
        {
            try
            {
                var results = this.UOW.Usuarios.List().Where(x => x.Nome.Contains(nome));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(UsuarioModel entity)
        {
            try
            {
                this.UOW.Usuarios.Update(entity);
                this.UOW.Commit();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.UOW.Dispose();
                this.UOW = null;
            }
        }
    }
}
