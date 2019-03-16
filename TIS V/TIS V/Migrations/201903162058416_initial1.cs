namespace TIS_V.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cartaos", new[] { "jogo_id" });
            DropIndex("dbo.Jogadors", new[] { "time_id" });
            DropIndex("dbo.Jogoes", new[] { "mandante_id" });
            DropIndex("dbo.Escalacaos", new[] { "jogo_id" });
            DropIndex("dbo.Escalacaos", new[] { "time_id" });
            DropIndex("dbo.Escanteios", new[] { "jogo_id" });
            DropIndex("dbo.Escanteios", new[] { "time_id" });
            DropIndex("dbo.Faltas", new[] { "jogo_id" });
            DropIndex("dbo.Faltas", new[] { "time_id" });
            DropIndex("dbo.Gols", new[] { "jogo_id" });
            DropIndex("dbo.Penaltis", new[] { "jogo_id" });
            DropIndex("dbo.Penaltis", new[] { "time_id" });
            DropIndex("dbo.Resultadoes", new[] { "jogo_id" });
            DropIndex("dbo.Resultadoes", new[] { "time_id" });
            DropIndex("dbo.Subtituicaos", new[] { "jogo_id" });
            DropIndex("dbo.Subtituicaos", new[] { "time_id" });
            AlterColumn("dbo.Cartaos", "jogo_id", c => c.Int());
            AlterColumn("dbo.Jogadors", "time_id", c => c.Int());
            AlterColumn("dbo.Jogoes", "mandante_id", c => c.Int());
            AlterColumn("dbo.Escalacaos", "jogo_id", c => c.Int());
            AlterColumn("dbo.Escalacaos", "time_id", c => c.Int());
            AlterColumn("dbo.Escanteios", "jogo_id", c => c.Int());
            AlterColumn("dbo.Escanteios", "time_id", c => c.Int());
            AlterColumn("dbo.Faltas", "jogo_id", c => c.Int());
            AlterColumn("dbo.Faltas", "time_id", c => c.Int());
            AlterColumn("dbo.Gols", "jogo_id", c => c.Int());
            AlterColumn("dbo.Penaltis", "jogo_id", c => c.Int());
            AlterColumn("dbo.Penaltis", "time_id", c => c.Int());
            AlterColumn("dbo.Resultadoes", "jogo_id", c => c.Int());
            AlterColumn("dbo.Resultadoes", "time_id", c => c.Int());
            AlterColumn("dbo.Subtituicaos", "jogo_id", c => c.Int());
            AlterColumn("dbo.Subtituicaos", "time_id", c => c.Int());
            CreateIndex("dbo.Cartaos", "jogo_id");
            CreateIndex("dbo.Jogadors", "time_id");
            CreateIndex("dbo.Jogoes", "mandante_id");
            CreateIndex("dbo.Escalacaos", "jogo_id");
            CreateIndex("dbo.Escalacaos", "time_id");
            CreateIndex("dbo.Escanteios", "jogo_id");
            CreateIndex("dbo.Escanteios", "time_id");
            CreateIndex("dbo.Faltas", "jogo_id");
            CreateIndex("dbo.Faltas", "time_id");
            CreateIndex("dbo.Gols", "jogo_id");
            CreateIndex("dbo.Penaltis", "jogo_id");
            CreateIndex("dbo.Penaltis", "time_id");
            CreateIndex("dbo.Resultadoes", "jogo_id");
            CreateIndex("dbo.Resultadoes", "time_id");
            CreateIndex("dbo.Subtituicaos", "jogo_id");
            CreateIndex("dbo.Subtituicaos", "time_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subtituicaos", new[] { "time_id" });
            DropIndex("dbo.Subtituicaos", new[] { "jogo_id" });
            DropIndex("dbo.Resultadoes", new[] { "time_id" });
            DropIndex("dbo.Resultadoes", new[] { "jogo_id" });
            DropIndex("dbo.Penaltis", new[] { "time_id" });
            DropIndex("dbo.Penaltis", new[] { "jogo_id" });
            DropIndex("dbo.Gols", new[] { "jogo_id" });
            DropIndex("dbo.Faltas", new[] { "time_id" });
            DropIndex("dbo.Faltas", new[] { "jogo_id" });
            DropIndex("dbo.Escanteios", new[] { "time_id" });
            DropIndex("dbo.Escanteios", new[] { "jogo_id" });
            DropIndex("dbo.Escalacaos", new[] { "time_id" });
            DropIndex("dbo.Escalacaos", new[] { "jogo_id" });
            DropIndex("dbo.Jogoes", new[] { "mandante_id" });
            DropIndex("dbo.Jogadors", new[] { "time_id" });
            DropIndex("dbo.Cartaos", new[] { "jogo_id" });
            AlterColumn("dbo.Subtituicaos", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Subtituicaos", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Resultadoes", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Resultadoes", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Penaltis", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Penaltis", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Gols", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Faltas", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Faltas", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Escanteios", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Escanteios", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Escalacaos", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Escalacaos", "jogo_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Jogoes", "mandante_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Jogadors", "time_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Cartaos", "jogo_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Subtituicaos", "time_id");
            CreateIndex("dbo.Subtituicaos", "jogo_id");
            CreateIndex("dbo.Resultadoes", "time_id");
            CreateIndex("dbo.Resultadoes", "jogo_id");
            CreateIndex("dbo.Penaltis", "time_id");
            CreateIndex("dbo.Penaltis", "jogo_id");
            CreateIndex("dbo.Gols", "jogo_id");
            CreateIndex("dbo.Faltas", "time_id");
            CreateIndex("dbo.Faltas", "jogo_id");
            CreateIndex("dbo.Escanteios", "time_id");
            CreateIndex("dbo.Escanteios", "jogo_id");
            CreateIndex("dbo.Escalacaos", "time_id");
            CreateIndex("dbo.Escalacaos", "jogo_id");
            CreateIndex("dbo.Jogoes", "mandante_id");
            CreateIndex("dbo.Jogadors", "time_id");
            CreateIndex("dbo.Cartaos", "jogo_id");
        }
    }
}
