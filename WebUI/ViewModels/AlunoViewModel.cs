using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class AlunoViewModel
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int TurmaID { get; set; }
        public TurmaModel TurmaSelecionada { get; set; }
        public List<TurmaModel> Turmas { get; set; }

        public int EscolaID { get; set; }
        public EscolaModel EscolaSelecionada { get; set; }
        public List<EscolaModel> Escolas { get; set; }

        public int FotoID { get; set; }
        public FotoModel Foto { get; set; }

        public int UserID { get; set; }
        public UsuarioModel UserFK { get; set; }
        public List<AlunoModel> Alunos { get; set; }

    }
}