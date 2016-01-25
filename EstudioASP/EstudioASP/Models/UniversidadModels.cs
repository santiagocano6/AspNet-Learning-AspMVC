using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstudioASP.Models
{
    public class UniversidadModels
    {
        [Key]
        [Required]
        public int UniversidadID { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int PaisId { get; set; }
        public virtual PaisModels PaisModels { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }
    }
}