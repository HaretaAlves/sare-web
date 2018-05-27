using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("AvaliacaoAluno")]
    public class AvaliacaoAlunoModel
    {
        public int ID { get; set; }
        public int Funcao { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Respostas { get; set; }

        public int AlunoID { get; set; }
        [ForeignKey("AlunoID")]
        public AlunoModel AlunoFK { get; set; }

        public int AvaliacaoGrupoID { get; set; }
        [ForeignKey("AvaliacaoGrupoID")]
        public AvaliacaoGrupoModel AvGrupoFK { get; set; }

    }
}