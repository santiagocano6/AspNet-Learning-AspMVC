using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudioASP.Models
{
    [Table("Noticias")]
    public class NoticiaModels
    {
            [Key]
            public Guid NoticiaID { get; set; }

            [Required]
            public string TituloNoticia { get; set; }

            [Required]
            public string DetalleNoticia { get; set; }

            public string RutaImagen { get; set; }

            [Required]
            public bool Publico { get; set; }
    }
}
