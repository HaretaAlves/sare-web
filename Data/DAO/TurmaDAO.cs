using Data;
using Domain.Models;
using Interfaces.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TurmaDAO : SARERepository<TurmaModel>, ITurmaDAO<TurmaModel>
    {
        public TurmaDAO(DbContext dbContext)
            : base(dbContext)
        { }

        public virtual IQueryable<TurmaModel> ListByEscolaID(int escolaID)
        {
            try
            {
                return this._dbSet.Where(x => x.EscolaID == escolaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual TurmaModel GetByNome(string nome)
        {
            try
            {
                return this._dbSet.Where(x => x.Nome == nome).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
