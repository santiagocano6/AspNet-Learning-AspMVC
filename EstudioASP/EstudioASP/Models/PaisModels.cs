using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudioASP.Models
{
    [Table("Pais")]
    public class PaisModels
    {
        [Key]
        [Required]
        public int PaisID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }
        public virtual ICollection<UniversidadModels> UniversidadModels { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

    }
}