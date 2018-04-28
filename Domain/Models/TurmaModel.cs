using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Turma")]
    public class TurmaModel
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int EscolaID { get; set; }
        [ForeignKey("EscolaID")]
        public EscolaModel EscolaFK { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public UsuarioModel UserFK { get; set; }

        public virtual ICollection<AlunoModel> Alunos { get; set; }

        public virtual ICollection<GrupoModel> Grupos { get; set; }
    }
}
