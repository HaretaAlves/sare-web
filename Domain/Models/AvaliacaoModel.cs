using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Avaliacao")]
    public class AvaliacaoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public UsuarioModel UserFK { get; set; }

        public virtual ICollection<AvaliacaoPerguntasModel> Perguntas { get; set; }
    }
}
