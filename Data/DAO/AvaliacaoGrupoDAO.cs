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
    public class AvaliacaoGrupoDAO : SARERepository<AvaliacaoGrupoModel>, IAvaliacaoGrupoDAO<AvaliacaoGrupoModel>
    {
        public AvaliacaoGrupoDAO(DbContext dbContext): base(dbContext)
        {

        }
    }
}
