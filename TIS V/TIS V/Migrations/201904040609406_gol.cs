namespace TIS_V.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gols", "time_id", c => c.Int());
            CreateIndex("dbo.Gols", "time_id");
            AddForeignKey("dbo.Gols", "time_id", "dbo.Equipes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gols", "time_id", "dbo.Equipes");
            DropIndex("dbo.Gols", new[] { "time_id" });
            DropColumn("dbo.Gols", "time_id");
        }
    }
}
