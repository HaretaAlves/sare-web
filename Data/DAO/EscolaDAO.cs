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
    public class EscolaDAO : SARERepository<EscolaModel>, IEscolaDAO<EscolaModel>
    {
        public EscolaDAO(DbContext dbContext): base(dbContext)
        {

        }

        public virtual EscolaModel GetByNome(string nome)
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
