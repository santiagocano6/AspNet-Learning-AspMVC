namespace EstudioASP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

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
            context.IdiomaModels.AddOrUpdate(
              p => p.IdiomaID,
              new IdiomaModels { IdiomaID = 1, Nombre = "Español" },
              new IdiomaModels { IdiomaID = 2, Nombre = "English" }
            );

            context.PaisModels.AddOrUpdate(
              p => p.PaisID,
              new PaisModels { PaisID = 1, Nombre = "Colombia" },
              new PaisModels { PaisID = 2, Nombre = "España" },
              new PaisModels { PaisID = 3, Nombre = "Perú" },
              new PaisModels { PaisID = 4, Nombre = "Estados Unidos" },
              new PaisModels { PaisID = 5, Nombre = "Inglaterra" }
            );

            context.UniversidadModels.AddOrUpdate(
              p => p.UniversidadID,
              new UniversidadModels { UniversidadID = 1, Nombre = "TdeA", PaisID = 1 },
              new UniversidadModels { UniversidadID = 2, Nombre = "Politecnico JIC", PaisID = 1 },
              new UniversidadModels { UniversidadID = 3, Nombre = "UdeA", PaisID = 1 },
              new UniversidadModels { UniversidadID = 4, Nombre = "Universida de Cataluña", PaisID = 2 },
              new UniversidadModels { UniversidadID = 5, Nombre = "Cambrish", PaisID = 4 }
            );
        }
    }
}
