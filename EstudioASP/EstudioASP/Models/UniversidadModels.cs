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
        public int PaisID { get; set; }
        public virtual PaisModels PaisModels { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        //public virtual ICollection<RegisterViewModel> RegisterViewModel { get; set; }
    }
}