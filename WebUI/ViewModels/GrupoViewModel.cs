using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class GrupoViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int Aluno1ID { get; set; }
        public AlunoModel Aluno1 { get; set; }

        public int Aluno2ID { get; set; }
        public AlunoModel Aluno2 { get; set; }

        public int Aluno3ID { get; set; }
        public AlunoModel Aluno3 { get; set; }

        public int Aluno4ID { get; set; }
        public AlunoModel Aluno4 { get; set; }

        public int TurmaID { get; set; }
        public TurmaModel TurmaSelecionada { get; set; }

        public int UserID { get; set; }
        public UsuarioModel User { get; set; }

        public List<AlunoModel> Alunos { get; set; }
        public List<TurmaModel> Turmas { get; set; }
        public List<GrupoModel> Grupos { get; set; }

    }
}