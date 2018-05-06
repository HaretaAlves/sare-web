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
    public class TurmaBusiness : ITurmaBusiness
    {
        private IUnitOfWork UOW = null;

        public TurmaBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        public TurmaModel Add(TurmaModel entity)
        {
            try
            {
                var turma = this.UOW.Turmas.Insert(entity);
                this.UOW.Commit();

                return turma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(TurmaModel entity)
        {            
            try
            {
                if(entity.ID > 0)
                {
                    this.UOW.Turmas.Delete(entity.ID);
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

        public TurmaModel GetById(int id)
        {
            try
            {
                var turma = this.UOW.Turmas.GetById(id);
                return turma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<TurmaModel> ListAll()
        {
            try
            {
                var turmas = this.UOW.Turmas.List();
                return turmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<TurmaModel> ListByEscolaID(int escolaID)
        {
            try
            {
                var results = this.UOW.Turmas.ListByEscolaID(escolaID);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<TurmaModel> ListAllByNome(string nome)
        {
            try
            {
                var results = this.UOW.Turmas.List().Where(x => x.Nome.Contains(nome));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(TurmaModel entity)
        {
            try
            {
                this.UOW.Turmas.Update(entity);
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
