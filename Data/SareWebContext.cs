using Domain.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SareWebContext : DbContext
    {
        public SareWebContext() : base("SareWebContext") { }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<AvaliacaoAlunoModel> AvaliacoesAlunos { get; set; }
        public DbSet<AvaliacaoGrupoModel> AvaliacoesGrupos { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<AvaliacaoPerguntasModel> Perguntas { get; set; }
        public DbSet<AvaliacaoRespostasModel> Respostas { get; set; }
        public DbSet<EscolaModel> Escolas { get; set; }
        public DbSet<FotoModel> Fotos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<GrupoModel> Grupos { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }

    }
}
