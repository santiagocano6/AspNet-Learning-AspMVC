namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testscr2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UniversidadModels",
                c => new
                    {
                        UniversidadID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        PaisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UniversidadID)
                .ForeignKey("dbo.PaisModels", t => t.PaisId, cascadeDelete: false)
                .Index(t => t.PaisId);
            
            AddColumn("dbo.DocumentoModels", "UniversidadID", c => c.Int(nullable: false));
            CreateIndex("dbo.DocumentoModels", "UniversidadID");
            AddForeignKey("dbo.DocumentoModels", "UniversidadID", "dbo.UniversidadModels", "UniversidadID", cascadeDelete: true);
            DropColumn("dbo.DocumentoModels", "Universidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DocumentoModels", "Universidad", c => c.String(nullable: false));
            DropForeignKey("dbo.UniversidadModels", "PaisId", "dbo.PaisModels");
            DropForeignKey("dbo.DocumentoModels", "UniversidadID", "dbo.UniversidadModels");
            DropIndex("dbo.UniversidadModels", new[] { "PaisId" });
            DropIndex("dbo.DocumentoModels", new[] { "UniversidadID" });
            DropColumn("dbo.DocumentoModels", "UniversidadID");
            DropTable("dbo.UniversidadModels");
        }
    }
}
