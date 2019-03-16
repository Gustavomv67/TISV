namespace TIS_V.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cartao = c.Int(nullable: false),
                        jogador_id = c.Int(),
                        jogo_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogadors", t => t.jogador_id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .Index(t => t.jogador_id)
                .Index(t => t.jogo_id);
            
            CreateTable(
                "dbo.Jogadors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        idade = c.Int(nullable: false),
                        numero = c.Int(nullable: false),
                        posicao = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.time_id);
            
            CreateTable(
                "dbo.Equipes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        pais = c.String(nullable: false),
                        estado = c.String(nullable: false),
                        cidade = c.String(nullable: false),
                        sigla = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Jogoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                        mandante_id = c.Int(nullable: false),
                        visitante_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Equipes", t => t.mandante_id)
                .ForeignKey("dbo.Equipes", t => t.visitante_id)
                .Index(t => t.mandante_id)
                .Index(t => t.visitante_id);
            
            CreateTable(
                "dbo.Escalacaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        posicao = c.Int(nullable: false),
                        jogador_id = c.Int(),
                        jogo_id = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogadors", t => t.jogador_id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.jogador_id)
                .Index(t => t.jogo_id)
                .Index(t => t.time_id);
            
            CreateTable(
                "dbo.Escanteios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jogo_id = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.jogo_id)
                .Index(t => t.time_id);
            
            CreateTable(
                "dbo.Faltas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jogador_id = c.Int(),
                        jogo_id = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogadors", t => t.jogador_id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.jogador_id)
                .Index(t => t.jogo_id)
                .Index(t => t.time_id);
            
            CreateTable(
                "dbo.Gols",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        falta = c.Boolean(nullable: false),
                        penalti = c.Boolean(nullable: false),
                        escanteio = c.Boolean(nullable: false),
                        jogador_id = c.Int(),
                        jogo_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogadors", t => t.jogador_id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .Index(t => t.jogador_id)
                .Index(t => t.jogo_id);
            
            CreateTable(
                "dbo.Penaltis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jogador_id = c.Int(),
                        jogo_id = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogadors", t => t.jogador_id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.jogador_id)
                .Index(t => t.jogo_id)
                .Index(t => t.time_id);
            
            CreateTable(
                "dbo.Resultadoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        gols1 = c.Int(nullable: false),
                        gols2 = c.Int(nullable: false),
                        posse1 = c.Int(nullable: false),
                        posse2 = c.Int(nullable: false),
                        jogo_id = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.jogo_id)
                .Index(t => t.time_id);
            
            CreateTable(
                "dbo.Subtituicaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jogadorEntrou_id = c.Int(),
                        jogadorSaiu_id = c.Int(),
                        jogo_id = c.Int(nullable: false),
                        time_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jogadors", t => t.jogadorEntrou_id)
                .ForeignKey("dbo.Jogadors", t => t.jogadorSaiu_id)
                .ForeignKey("dbo.Jogoes", t => t.jogo_id)
                .ForeignKey("dbo.Equipes", t => t.time_id)
                .Index(t => t.jogadorEntrou_id)
                .Index(t => t.jogadorSaiu_id)
                .Index(t => t.jogo_id)
                .Index(t => t.time_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subtituicaos", "time_id", "dbo.Equipes");
            DropForeignKey("dbo.Subtituicaos", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Subtituicaos", "jogadorSaiu_id", "dbo.Jogadors");
            DropForeignKey("dbo.Subtituicaos", "jogadorEntrou_id", "dbo.Jogadors");
            DropForeignKey("dbo.Resultadoes", "time_id", "dbo.Equipes");
            DropForeignKey("dbo.Resultadoes", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Penaltis", "time_id", "dbo.Equipes");
            DropForeignKey("dbo.Penaltis", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Penaltis", "jogador_id", "dbo.Jogadors");
            DropForeignKey("dbo.Gols", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Gols", "jogador_id", "dbo.Jogadors");
            DropForeignKey("dbo.Faltas", "time_id", "dbo.Equipes");
            DropForeignKey("dbo.Faltas", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Faltas", "jogador_id", "dbo.Jogadors");
            DropForeignKey("dbo.Escanteios", "time_id", "dbo.Equipes");
            DropForeignKey("dbo.Escanteios", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Escalacaos", "time_id", "dbo.Equipes");
            DropForeignKey("dbo.Escalacaos", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Escalacaos", "jogador_id", "dbo.Jogadors");
            DropForeignKey("dbo.Cartaos", "jogo_id", "dbo.Jogoes");
            DropForeignKey("dbo.Jogoes", "visitante_id", "dbo.Equipes");
            DropForeignKey("dbo.Jogoes", "mandante_id", "dbo.Equipes");
            DropForeignKey("dbo.Cartaos", "jogador_id", "dbo.Jogadors");
            DropForeignKey("dbo.Jogadors", "time_id", "dbo.Equipes");
            DropIndex("dbo.Subtituicaos", new[] { "time_id" });
            DropIndex("dbo.Subtituicaos", new[] { "jogo_id" });
            DropIndex("dbo.Subtituicaos", new[] { "jogadorSaiu_id" });
            DropIndex("dbo.Subtituicaos", new[] { "jogadorEntrou_id" });
            DropIndex("dbo.Resultadoes", new[] { "time_id" });
            DropIndex("dbo.Resultadoes", new[] { "jogo_id" });
            DropIndex("dbo.Penaltis", new[] { "time_id" });
            DropIndex("dbo.Penaltis", new[] { "jogo_id" });
            DropIndex("dbo.Penaltis", new[] { "jogador_id" });
            DropIndex("dbo.Gols", new[] { "jogo_id" });
            DropIndex("dbo.Gols", new[] { "jogador_id" });
            DropIndex("dbo.Faltas", new[] { "time_id" });
            DropIndex("dbo.Faltas", new[] { "jogo_id" });
            DropIndex("dbo.Faltas", new[] { "jogador_id" });
            DropIndex("dbo.Escanteios", new[] { "time_id" });
            DropIndex("dbo.Escanteios", new[] { "jogo_id" });
            DropIndex("dbo.Escalacaos", new[] { "time_id" });
            DropIndex("dbo.Escalacaos", new[] { "jogo_id" });
            DropIndex("dbo.Escalacaos", new[] { "jogador_id" });
            DropIndex("dbo.Jogoes", new[] { "visitante_id" });
            DropIndex("dbo.Jogoes", new[] { "mandante_id" });
            DropIndex("dbo.Jogadors", new[] { "time_id" });
            DropIndex("dbo.Cartaos", new[] { "jogo_id" });
            DropIndex("dbo.Cartaos", new[] { "jogador_id" });
            DropTable("dbo.Subtituicaos");
            DropTable("dbo.Resultadoes");
            DropTable("dbo.Penaltis");
            DropTable("dbo.Gols");
            DropTable("dbo.Faltas");
            DropTable("dbo.Escanteios");
            DropTable("dbo.Escalacaos");
            DropTable("dbo.Jogoes");
            DropTable("dbo.Equipes");
            DropTable("dbo.Jogadors");
            DropTable("dbo.Cartaos");
        }
    }
}
