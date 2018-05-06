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
    public class AlunoBusiness : IAlunoBusiness
    {
        private IUnitOfWork UOW = null;

        public AlunoBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        public AlunoModel Add(AlunoModel entity)
        {
            try
            {
                var aluno = this.UOW.Alunos.Insert(entity);
                this.UOW.Commit();

                return aluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(AlunoModel entity)
        {            
            try
            {
                if(entity.ID > 0)
                {
                    this.UOW.Alunos.Delete(entity.ID);
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

        public AlunoModel GetById(int id)
        {
            try
            {
                var aluno = this.UOW.Alunos.GetById(id);
                return aluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<AlunoModel> ListAll()
        {
            try
            {
                var alunos = this.UOW.Alunos.List();
                return alunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<AlunoModel> ListByTurmaID(int turmaID)
        {
            try
            {
                var results = this.UOW.Alunos.ListByTurmaID(turmaID);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<AlunoModel> ListAllByNome(string nome)
        {
            try
            {
                var results = this.UOW.Alunos.List().Where(x => x.Nome.Contains(nome));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(AlunoModel entity)
        {
            try
            {
                this.UOW.Alunos.Update(entity);
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
