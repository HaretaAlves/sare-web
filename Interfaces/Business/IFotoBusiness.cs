using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Business
{
    public interface IFotoBusiness : IBusinessBase<FotoModel>
    {
        FotoModel GetByAlunoId(int alunoId);
    }
}
