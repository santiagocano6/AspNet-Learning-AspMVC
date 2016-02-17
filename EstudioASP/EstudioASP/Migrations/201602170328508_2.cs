namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DocumentoModels", newName: "Documento");
            RenameTable(name: "dbo.IdiomaModels", newName: "Idioma");
            RenameTable(name: "dbo.PaisModels", newName: "Pais");
            RenameTable(name: "dbo.UniversidadModels", newName: "Universidad");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Universidad", newName: "UniversidadModels");
            RenameTable(name: "dbo.Pais", newName: "PaisModels");
            RenameTable(name: "dbo.Idioma", newName: "IdiomaModels");
            RenameTable(name: "dbo.Documento", newName: "DocumentoModels");
        }
    }
}
