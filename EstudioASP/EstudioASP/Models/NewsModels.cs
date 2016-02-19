using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudioASP.Models
{
    [Table("News")]
    public class NewsModels
    {
        [Key]
        public Guid NoticiaID { get; set; }

        public string TituloNoticia { get; set; }

        public string DetalleNoticia { get; set; }

        public string RutaImagen { get; set; }

        public bool Publico { get; set; }
    }
}