namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        NoticiaID = c.Guid(nullable: false),
                        TituloNoticia = c.String(nullable: false),
                        DetalleNoticia = c.String(nullable: false),
                        RutaImagen = c.String(),
                        Publico = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NoticiaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Noticias");
        }
    }
}
