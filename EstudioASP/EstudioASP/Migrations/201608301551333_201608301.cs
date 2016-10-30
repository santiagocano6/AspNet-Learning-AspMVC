namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201608301 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documento", "Descripcion", c => c.String(nullable: false));
            AddColumn("dbo.Documento", "Link", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documento", "Link");
            DropColumn("dbo.Documento", "Descripcion");
        }
    }
}
