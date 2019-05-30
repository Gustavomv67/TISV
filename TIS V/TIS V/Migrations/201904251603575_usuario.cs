namespace TIS_V.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        senha = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
