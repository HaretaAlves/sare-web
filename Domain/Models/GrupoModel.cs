using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Grupo")]
    public class GrupoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int Aluno1ID { get; set; }
        [ForeignKey("Aluno1ID")]
        public AlunoModel Aluno1FK { get; set; }

        public int Aluno2ID { get; set; }
        [ForeignKey("Aluno2ID")]
        public AlunoModel Aluno2FK { get; set; }

        public int Aluno3ID { get; set; }
        [ForeignKey("Aluno3ID")]
        public AlunoModel Aluno3FK { get; set; }

        public int Aluno4ID { get; set; }
        [ForeignKey("Aluno4ID")]
        public AlunoModel Aluno4FK { get; set; }

        public int TurmaID { get; set; }
        [ForeignKey("TurmaID")]
        public TurmaModel TurmaFK { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public UsuarioModel UserFK { get; set; }

        public virtual ICollection<AvaliacaoGrupoModel> AvaliacoesGrupo { get; set; }
    }
}
