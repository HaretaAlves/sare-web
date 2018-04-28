using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Fotos")]
    public class FotoModel
    {
        public int ID { get; set; }
        public string FotoUrl { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
