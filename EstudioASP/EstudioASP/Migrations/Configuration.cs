namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EstudioASP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EstudioASP.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.PaisModels.AddOrUpdate(
              p => p.PaisID,
              new Models.PaisModels { PaisID = 1, Nombre = "Colombia" },
              new Models.PaisModels { PaisID = 2, Nombre = "España" },
              new Models.PaisModels { PaisID = 3, Nombre = "Mexico" }
              );

            context.IdiomaModels.AddOrUpdate(
              p => p.IdiomaID,
              new Models.IdiomaModels { IdiomaID = 1, Nombre = "Español" },
              new Models.IdiomaModels { IdiomaID = 2, Nombre = "Inglés" }
              );

            context.UniversidadModels.AddOrUpdate(
              p => p.UniversidadID,
              new Models.UniversidadModels { UniversidadID = 1, Nombre = "TdeA", PaisId = 1 },
              new Models.UniversidadModels { UniversidadID = 2, Nombre = "Poli", PaisId = 1 },
              new Models.UniversidadModels { UniversidadID = 2, Nombre = "UMadrir", PaisId = 2 }
              );

            //
        }
    }
}
