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
    public class FotoDAO : SARERepository<FotoModel>, IFotoDAO<FotoModel>
    {
        public FotoDAO(DbContext dbContext): base(dbContext)
        {

        }

        public virtual FotoModel GetByAlunoId(int alunoId)
        {
            try
            {
                return this._dbSet.Where(x => x.AlunoID == alunoId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
