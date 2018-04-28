using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("AvaliacaoPerguntas")]
    public class AvaliacaoPerguntasModel
    {
        public int ID { get; set; }
        public string Pergunta { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int AvaliacaoID { get; set; }
        [ForeignKey("AvaliacaoID")]
        public AvaliacaoModel AvaliacaoFK { get; set; }

        public virtual ICollection<AvaliacaoRespostasModel> Respostas { get; set; }

    }
}