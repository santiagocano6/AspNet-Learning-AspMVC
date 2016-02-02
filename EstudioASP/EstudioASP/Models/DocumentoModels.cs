using System;
using System.ComponentModel.DataAnnotations;

namespace EstudioASP.Models
{
    public enum Calificacion
    {
        Alta = 5, Media_Alta = 4, Media = 3, Media_Baja = 3, Baja = 1
    }
    public enum Calidad
    {
        Alta = 3, Media = 2, Baja = 1
    }

    public class DocumentoModels
    {
        [Key]
        [Required(ErrorMessage = "ID es requerido.")]
        public int DocumentoId { get; set; }

        [Required]
        [Display(Name = "Nombre documento")]
        public string NombreDocumento { get; set; }

        [Required]
        public string Materia { get; set; }

        [Required]
        [Display(Name = "Calificación")]
        public Calificacion CalificacionDocumento { get; set; }

        [Required]
        public Calidad CalidadDocumento { get; set; }

        [Required]
        [Display(Name = "Fecha Documento")]
        [DataType(DataType.Date)]
        public DateTime FechaDocumento { get; set; }

        [Required]
        [Display(Name = "Fecha Creación")]
        [DataType(DataType.Date)]
        [Editable(false, AllowInitialValue = false)]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Display(Name = "País", Description = "País del documento")]
        public int PaisID { get; set; }
        public virtual PaisModels PaisModels { get; set; }

        [Required]
        [Display(Name = "Idioma")]
        public int IdiomaID { get; set; }
        public virtual IdiomaModels IdiomaModels { get; set; }

        [Required]
        [Display(Name = "Universidad")]
        public int? UniversidadID { get; set; }
        public virtual UniversidadModels UniversidadModels { get; set; }

        [Display(Name = "Usuario")]
        [Editable(false, AllowInitialValue = false)]
        public Guid? ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}