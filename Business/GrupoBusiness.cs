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
    public class GrupoBusiness : IGrupoBusiness
    {
        private IUnitOfWork UOW = null;

        public GrupoBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        public GrupoModel Add(GrupoModel entity)
        {
            try
            {
                var grupo = this.UOW.Grupos.Insert(entity);
                this.UOW.Commit();

                return grupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(GrupoModel entity)
        {            
            try
            {
                if(entity.ID > 0)
                {
                    this.UOW.Grupos.Delete(entity.ID);
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

        public GrupoModel GetById(int id)
        {
            try
            {
                var grupo = this.UOW.Grupos.GetById(id);
                return grupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<GrupoModel> ListAll()
        {
            try
            {
                var grupos = this.UOW.Grupos.List();
                return grupos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<GrupoModel> ListAllByNome(string nome)
        {
            try
            {
                var results = this.UOW.Grupos.List().Where(x => x.Nome.Contains(nome));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(GrupoModel entity)
        {
            try
            {
                this.UOW.Grupos.Update(entity);
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
