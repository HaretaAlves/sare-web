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
    public class EscolaBusiness : IEscolaBusiness
    {
        private IUnitOfWork UOW = null;

        public EscolaBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        public EscolaModel Add(EscolaModel entity)
        {
            try
            {
                var escola = this.UOW.Escolas.Insert(entity);
                this.UOW.Commit();

                return escola;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(EscolaModel entity)
        {            
            try
            {
                if(entity.ID > 0)
                {
                    this.UOW.Escolas.Delete(entity.ID);
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

        public EscolaModel GetById(int id)
        {
            try
            {
                var escola = this.UOW.Escolas.GetById(id);
                return escola;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<EscolaModel> ListAll()
        {
            try
            {
                var escolas = this.UOW.Escolas.List();
                return escolas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<EscolaModel> ListAllByNome(string nome)
        {
            try
            {
                var results = this.UOW.Escolas.List().Where(x => x.Nome.Contains(nome));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(EscolaModel entity)
        {
            try
            {
                this.UOW.Escolas.Update(entity);
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
