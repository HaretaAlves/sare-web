using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("AvaliacaoRespostas")]
    public class AvaliacaoRespostasModel
    {
        public int ID { get; set; }
        public string Resposta { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int PerguntaID { get; set; }
        [ForeignKey("PerguntaID")]
        public AvaliacaoPerguntasModel AvPerguntaFK { get; set; }

    }
}
