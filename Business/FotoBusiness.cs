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
    public class FotoBusiness : IFotoBusiness
    {
        private IUnitOfWork UOW = null;

        public FotoBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        public FotoModel Add(FotoModel entity)
        {
            try
            {
                var foto = this.UOW.Fotos.Insert(entity);
                this.UOW.Commit();

                return foto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(FotoModel entity)
        {            
            try
            {
                if(entity.ID > 0)
                {
                    this.UOW.Fotos.Delete(entity.ID);
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

        public FotoModel GetById(int id)
        {
            try
            {
                var foto = this.UOW.Fotos.GetById(id);
                return foto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FotoModel GetByAlunoId(int alunoId)
        {
            try
            {
                var foto = this.UOW.Fotos.GetByAlunoId(alunoId);
                return foto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<FotoModel> ListAll()
        {
            try
            {
                var fotos = this.UOW.Fotos.List();
                return fotos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(FotoModel entity)
        {
            try
            {
                this.UOW.Fotos.Update(entity);
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
