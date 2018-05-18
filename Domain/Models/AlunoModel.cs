using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    //Candidatas para tornarem-se revendedoras
    [Table("Aluno")]
    public class AlunoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int TurmaID { get; set; }
        [ForeignKey("TurmaID")]
        public TurmaModel TurmaFK { get; set; }
        
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public UsuarioModel UserFK { get; set; }

        public virtual ICollection<AvaliacaoAlunoModel> AvaliacoesAluno { get; set; }

    }
}