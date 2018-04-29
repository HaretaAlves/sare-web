using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class TurmaViewModel
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int EscolaID { get; set; }
        public EscolaModel EscolaSelecionada { get; set; }
        public List<EscolaModel> Escolas { get; set; }

        public List<TurmaModel> Turmas { get; set; }

    }
}