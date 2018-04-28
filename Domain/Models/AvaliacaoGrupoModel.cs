using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("AvaliacaoGrupo")]
    public class AvaliacaoGrupoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int GrupoID { get; set; }
        [ForeignKey("GrupoID")]
        public GrupoModel GrupoFK { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public UsuarioModel UserFK { get; set; }

        public virtual ICollection<AvaliacaoAlunoModel> AvaliacoesAluno { get; set; }
    }
}