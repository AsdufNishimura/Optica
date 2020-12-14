using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Producto
    {
        [Key]
        [Required]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(110, ErrorMessage = "La descripción es demasiado larga.")]
        public string Descripcion { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PrecioUnitario { get; set; }
    }
}