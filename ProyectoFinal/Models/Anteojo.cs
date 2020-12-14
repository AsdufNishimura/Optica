using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Anteojo
    {
        [Key]
        [Required]
        public int AnteojoId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El nombre para este modelo de anteojos es demasiado largo.")]
        public string NombreModelo { get; set; }

        [Required]
        public int TamañoId { get; set; }

        [Required]
        public int EstiloId { get; set; }

        [Required]
        public int ColorId { get; set; }



        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        [ForeignKey("TamañoId")]
        public virtual Tamaño Tamaño { get; set; }

        [ForeignKey("EstiloId")]
        public virtual Estilo Estilo { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }
}