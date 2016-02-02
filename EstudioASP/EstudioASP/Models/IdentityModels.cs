using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EstudioASP.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public int? IdiomaID { get; set; }
        public virtual IdiomaModels IdiomaModels { get; set; }

        public int? UniversidadID { get; set; }
        public virtual UniversidadModels UniversidadModels { get; set; }

        public int? PaisID { get; set; }
        public virtual PaisModels PaisModels { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("EstudioASPContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EstudioASP.Models.DocumentoModels> DocumentoModels { get; set; }

        public System.Data.Entity.DbSet<EstudioASP.Models.IdiomaModels> IdiomaModels { get; set; }

        public System.Data.Entity.DbSet<EstudioASP.Models.PaisModels> PaisModels { get; set; }

        public System.Data.Entity.DbSet<EstudioASP.Models.UniversidadModels> UniversidadModels { get; set; }
    }
}