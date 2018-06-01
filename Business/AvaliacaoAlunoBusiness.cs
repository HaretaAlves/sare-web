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
    public class AvaliacaoAlunoBusiness : IAvaliacaoAlunoBusiness
    {
        private IUnitOfWork UOW = null;

        public AvaliacaoAlunoBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        //NÃO É NECESSÁRIO
        public AvaliacaoAlunoModel Add(AvaliacaoAlunoModel entity)
        {
            try
            {
                var avaliacaoAluno = this.UOW.AvaliacoesAluno.Insert(entity);

                return avaliacaoAluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        

        //NÃO É NECESSÁRIO
        public bool Delete(AvaliacaoAlunoModel entity)
        {            
            try
            {                
                return false;
            }            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public AvaliacaoAlunoModel GetById(int id)
        {
            try
            {
                var avaliacaoAluno = this.UOW.AvaliacoesAluno.GetById(id);
                return avaliacaoAluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IQueryable<AvaliacaoAlunoModel> ListAll()
        {
            try
            {
                var avaliacaoAluno = this.UOW.AvaliacoesAluno.List();
                return avaliacaoAluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<AvaliacaoAlunoModel> ListAllByAvGrupoID(int avaliacaoGrupoId)
        {
            try
            {
                var avaliacoesAluno = this.UOW.AvaliacoesAluno.List().Where(x => x.AvaliacaoGrupoID == avaliacaoGrupoId);
                return avaliacoesAluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //NÃO É NECESSÁRIO
        public bool Update(AvaliacaoAlunoModel entity)
        {
            try
            {
                this.UOW.AvaliacoesAluno.Update(entity);
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
