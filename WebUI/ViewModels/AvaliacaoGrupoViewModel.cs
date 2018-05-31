using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class AvaliacaoGrupoViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int GrupoID { get; set; }
        public GrupoModel Grupo { get; set; }

        public int UserID { get; set; }
        public UsuarioModel User { get; set; }

        public List<AvaliacaoGrupoModel> AvaliacoesGrupo { get; set; }

    }
}