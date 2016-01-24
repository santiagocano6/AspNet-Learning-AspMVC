namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testscr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentoModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreDocumento = c.String(nullable: false),
                        Materia = c.String(nullable: false),
                        Universidad = c.String(nullable: false),
                        Calificacion = c.Int(nullable: false),
                        Calidad = c.Int(nullable: false),
                        FechaDocumento = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PaisID = c.Int(nullable: false),
                        IdiomaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IdiomaModels", t => t.IdiomaID, cascadeDelete: true)
                .ForeignKey("dbo.PaisModels", t => t.PaisID, cascadeDelete: true)
                .Index(t => t.PaisID)
                .Index(t => t.IdiomaID);
            
            CreateTable(
                "dbo.IdiomaModels",
                c => new
                    {
                        IdiomaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdiomaID);
            
            CreateTable(
                "dbo.PaisModels",
                c => new
                    {
                        PaisID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaisID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentoModels", "PaisID", "dbo.PaisModels");
            DropForeignKey("dbo.DocumentoModels", "IdiomaID", "dbo.IdiomaModels");
            DropIndex("dbo.DocumentoModels", new[] { "IdiomaID" });
            DropIndex("dbo.DocumentoModels", new[] { "PaisID" });
            DropTable("dbo.PaisModels");
            DropTable("dbo.IdiomaModels");
            DropTable("dbo.DocumentoModels");
        }
    }
}
