using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudioASP.Models
{
    [Table("Idioma")]
    public class IdiomaModels
    {
        [Key]
        [Required]
        public int IdiomaID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<DocumentoModels> DocumentoModels { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        //public virtual ICollection<RegisterViewModel> RegisterViewModel { get; set; }
    }
}