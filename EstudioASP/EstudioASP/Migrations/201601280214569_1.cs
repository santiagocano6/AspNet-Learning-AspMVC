namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentoModels",
                c => new
                    {
                        DocumentoId = c.Int(nullable: false, identity: true),
                        NombreDocumento = c.String(nullable: false),
                        Materia = c.String(nullable: false),
                        CalificacionDocumento = c.Int(nullable: false),
                        CalidadDocumento = c.Int(nullable: false),
                        FechaDocumento = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PaisID = c.Int(nullable: false),
                        IdiomaID = c.Int(nullable: false),
                        UniversidadID = c.Int(nullable: false),
                        ApplicationUserID = c.Guid(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DocumentoId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdiomaModels", t => t.IdiomaID, cascadeDelete: false)
                .ForeignKey("dbo.PaisModels", t => t.PaisID, cascadeDelete: false)
                .ForeignKey("dbo.UniversidadModels", t => t.UniversidadID, cascadeDelete: false)
                .Index(t => t.PaisID)
                .Index(t => t.IdiomaID)
                .Index(t => t.UniversidadID)
                .Index(t => t.ApplicationUser_Id);
            
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
            
            CreateTable(
                "dbo.UniversidadModels",
                c => new
                    {
                        UniversidadID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        PaisID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UniversidadID)
                .ForeignKey("dbo.PaisModels", t => t.PaisID, cascadeDelete: false)
                .Index(t => t.PaisID);
            
            AddColumn("dbo.AspNetUsers", "IdiomaID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "UniversidadID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PaisID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "IdiomaID");
            CreateIndex("dbo.AspNetUsers", "UniversidadID");
            CreateIndex("dbo.AspNetUsers", "PaisID");
            AddForeignKey("dbo.AspNetUsers", "IdiomaID", "dbo.IdiomaModels", "IdiomaID");
            AddForeignKey("dbo.AspNetUsers", "PaisID", "dbo.PaisModels", "PaisID");
            AddForeignKey("dbo.AspNetUsers", "UniversidadID", "dbo.UniversidadModels", "UniversidadID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UniversidadModels", "PaisID", "dbo.PaisModels");
            DropForeignKey("dbo.DocumentoModels", "UniversidadID", "dbo.UniversidadModels");
            DropForeignKey("dbo.AspNetUsers", "UniversidadID", "dbo.UniversidadModels");
            DropForeignKey("dbo.DocumentoModels", "PaisID", "dbo.PaisModels");
            DropForeignKey("dbo.AspNetUsers", "PaisID", "dbo.PaisModels");
            DropForeignKey("dbo.DocumentoModels", "IdiomaID", "dbo.IdiomaModels");
            DropForeignKey("dbo.AspNetUsers", "IdiomaID", "dbo.IdiomaModels");
            DropForeignKey("dbo.DocumentoModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UniversidadModels", new[] { "PaisID" });
            DropIndex("dbo.AspNetUsers", new[] { "PaisID" });
            DropIndex("dbo.AspNetUsers", new[] { "UniversidadID" });
            DropIndex("dbo.AspNetUsers", new[] { "IdiomaID" });
            DropIndex("dbo.DocumentoModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.DocumentoModels", new[] { "UniversidadID" });
            DropIndex("dbo.DocumentoModels", new[] { "IdiomaID" });
            DropIndex("dbo.DocumentoModels", new[] { "PaisID" });
            DropColumn("dbo.AspNetUsers", "PaisID");
            DropColumn("dbo.AspNetUsers", "UniversidadID");
            DropColumn("dbo.AspNetUsers", "IdiomaID");
            DropTable("dbo.UniversidadModels");
            DropTable("dbo.PaisModels");
            DropTable("dbo.IdiomaModels");
            DropTable("dbo.DocumentoModels");
        }
    }
}
