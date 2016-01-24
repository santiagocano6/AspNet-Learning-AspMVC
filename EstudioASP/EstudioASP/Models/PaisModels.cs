using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstudioASP.Models
{
    public class PaisModels
    { 
        [Key]
        [Required]
        public int PaisID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }
    }
}
