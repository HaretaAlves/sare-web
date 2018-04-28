namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        DataNascimento = c.DateTime(nullable: false, precision: 0),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        TurmaID = c.Int(nullable: false),
                        FotoID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Turma", t => t.TurmaID, cascadeDelete: true)
                .ForeignKey("dbo.Fotos", t => t.FotoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TurmaID)
                .Index(t => t.FotoID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AvaliacaoAluno",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Funcao = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        Respostas = c.String(unicode: false),
                        AlunoID = c.Int(nullable: false),
                        AvaliacaoGrupoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Aluno", t => t.AlunoID, cascadeDelete: true)
                .ForeignKey("dbo.AvaliacaoGrupo", t => t.AvaliacaoGrupoID, cascadeDelete: true)
                .Index(t => t.AlunoID)
                .Index(t => t.AvaliacaoGrupoID);
            
            CreateTable(
                "dbo.AvaliacaoGrupo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        GrupoID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grupo", t => t.GrupoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UserID, cascadeDelete: true)
                .Index(t => t.GrupoID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        Aluno1ID = c.Int(nullable: false),
                        Aluno2ID = c.Int(nullable: false),
                        Aluno3ID = c.Int(nullable: false),
                        Aluno4ID = c.Int(nullable: false),
                        TurmaID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Aluno", t => t.Aluno1ID, cascadeDelete: true)
                .ForeignKey("dbo.Aluno", t => t.Aluno2ID, cascadeDelete: true)
                .ForeignKey("dbo.Aluno", t => t.Aluno3ID, cascadeDelete: true)
                .ForeignKey("dbo.Aluno", t => t.Aluno4ID, cascadeDelete: true)
                .ForeignKey("dbo.Turma", t => t.TurmaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UserID, cascadeDelete: true)
                .Index(t => t.Aluno1ID)
                .Index(t => t.Aluno2ID)
                .Index(t => t.Aluno3ID)
                .Index(t => t.Aluno4ID)
                .Index(t => t.TurmaID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        EscolaID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escola", t => t.EscolaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UserID, cascadeDelete: true)
                .Index(t => t.EscolaID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Escola",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Login = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fotos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FotoUrl = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AvaliacaoPerguntas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pergunta = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        AvaliacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Avaliacao", t => t.AvaliacaoID, cascadeDelete: true)
                .Index(t => t.AvaliacaoID);
            
            CreateTable(
                "dbo.AvaliacaoRespostas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Resposta = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        LastModifiedDate = c.DateTime(nullable: false, precision: 0),
                        PerguntaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AvaliacaoPerguntas", t => t.PerguntaID, cascadeDelete: true)
                .Index(t => t.PerguntaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avaliacao", "UserID", "dbo.Usuarios");
            DropForeignKey("dbo.AvaliacaoRespostas", "PerguntaID", "dbo.AvaliacaoPerguntas");
            DropForeignKey("dbo.AvaliacaoPerguntas", "AvaliacaoID", "dbo.Avaliacao");
            DropForeignKey("dbo.Aluno", "UserID", "dbo.Usuarios");
            DropForeignKey("dbo.Aluno", "FotoID", "dbo.Fotos");
            DropForeignKey("dbo.AvaliacaoGrupo", "UserID", "dbo.Usuarios");
            DropForeignKey("dbo.Grupo", "UserID", "dbo.Usuarios");
            DropForeignKey("dbo.Turma", "UserID", "dbo.Usuarios");
            DropForeignKey("dbo.Grupo", "TurmaID", "dbo.Turma");
            DropForeignKey("dbo.Escola", "UserID", "dbo.Usuarios");
            DropForeignKey("dbo.Turma", "EscolaID", "dbo.Escola");
            DropForeignKey("dbo.Aluno", "TurmaID", "dbo.Turma");
            DropForeignKey("dbo.AvaliacaoGrupo", "GrupoID", "dbo.Grupo");
            DropForeignKey("dbo.Grupo", "Aluno4ID", "dbo.Aluno");
            DropForeignKey("dbo.Grupo", "Aluno3ID", "dbo.Aluno");
            DropForeignKey("dbo.Grupo", "Aluno2ID", "dbo.Aluno");
            DropForeignKey("dbo.Grupo", "Aluno1ID", "dbo.Aluno");
            DropForeignKey("dbo.AvaliacaoAluno", "AvaliacaoGrupoID", "dbo.AvaliacaoGrupo");
            DropForeignKey("dbo.AvaliacaoAluno", "AlunoID", "dbo.Aluno");
            DropIndex("dbo.AvaliacaoRespostas", new[] { "PerguntaID" });
            DropIndex("dbo.AvaliacaoPerguntas", new[] { "AvaliacaoID" });
            DropIndex("dbo.Avaliacao", new[] { "UserID" });
            DropIndex("dbo.Escola", new[] { "UserID" });
            DropIndex("dbo.Turma", new[] { "UserID" });
            DropIndex("dbo.Turma", new[] { "EscolaID" });
            DropIndex("dbo.Grupo", new[] { "UserID" });
            DropIndex("dbo.Grupo", new[] { "TurmaID" });
            DropIndex("dbo.Grupo", new[] { "Aluno4ID" });
            DropIndex("dbo.Grupo", new[] { "Aluno3ID" });
            DropIndex("dbo.Grupo", new[] { "Aluno2ID" });
            DropIndex("dbo.Grupo", new[] { "Aluno1ID" });
            DropIndex("dbo.AvaliacaoGrupo", new[] { "UserID" });
            DropIndex("dbo.AvaliacaoGrupo", new[] { "GrupoID" });
            DropIndex("dbo.AvaliacaoAluno", new[] { "AvaliacaoGrupoID" });
            DropIndex("dbo.AvaliacaoAluno", new[] { "AlunoID" });
            DropIndex("dbo.Aluno", new[] { "UserID" });
            DropIndex("dbo.Aluno", new[] { "FotoID" });
            DropIndex("dbo.Aluno", new[] { "TurmaID" });
            DropTable("dbo.AvaliacaoRespostas");
            DropTable("dbo.AvaliacaoPerguntas");
            DropTable("dbo.Avaliacao");
            DropTable("dbo.Fotos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Escola");
            DropTable("dbo.Turma");
            DropTable("dbo.Grupo");
            DropTable("dbo.AvaliacaoGrupo");
            DropTable("dbo.AvaliacaoAluno");
            DropTable("dbo.Aluno");
        }
    }
}
