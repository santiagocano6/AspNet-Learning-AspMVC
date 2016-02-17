using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudioASP.Models
{
    [Table("Universidad")]
    public class UniversidadModels
    {
        [Key]
        [Required]
        public int UniversidadID { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int PaisID { get; set; }
        public virtual PaisModels PaisModels { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

    }
}