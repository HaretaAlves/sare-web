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
    public class AvaliacaoGrupoBusiness : IAvaliacaoGrupoBusiness
    {
        private IUnitOfWork UOW = null;

        public AvaliacaoGrupoBusiness()
        {
            this.UOW = new UnitOfWork();
        }

        //NÃO É NECESSÁRIO
        public AvaliacaoGrupoModel Add(AvaliacaoGrupoModel entity)
        {
            try
            {
                var avaliacaoGrupo = this.UOW.AvaliacoesGrupo.Insert(entity);

                return avaliacaoGrupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        

        //NÃO É NECESSÁRIO
        public bool Delete(AvaliacaoGrupoModel entity)
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
        

        public AvaliacaoGrupoModel GetById(int id)
        {
            try
            {
                var avaliacaoGrupo = this.UOW.AvaliacoesGrupo.GetById(id);
                return avaliacaoGrupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<AvaliacaoGrupoModel> ListAll()
        {
            try
            {
                var avaliacaoGrupo = this.UOW.AvaliacoesGrupo.List();
                return avaliacaoGrupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<AvaliacaoGrupoModel> ListAllByNome(string nome)
        {
            try
            {
                var results = this.UOW.AvaliacoesGrupo.List().Where(x => x.Nome.Contains(nome));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //CORRIGIR IMPLEMENTAÇÃO DESSE METODO PARA PEGAR REGISTROS NO INTERVALO DE DATAS
        public IQueryable<AvaliacaoGrupoModel> ListAllByDate(DateTime date)
        {
            try
            {
                var results = this.UOW.AvaliacoesGrupo.List().Where(x => x.Date.Day.Equals(date.Day));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //NÃO É NECESSÁRIO
        public bool Update(AvaliacaoGrupoModel entity)
        {
            try
            {
                this.UOW.AvaliacoesGrupo.Update(entity);
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
