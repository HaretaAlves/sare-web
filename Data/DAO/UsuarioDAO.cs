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
    public class UsuarioDAO : SARERepository<UsuarioModel>, IUsuarioDAO<UsuarioModel>
    {
        public UsuarioDAO(DbContext dbContext): base(dbContext)
        {

        }
    }
}
