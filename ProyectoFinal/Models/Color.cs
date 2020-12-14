using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Color
    {
        [Key]
        [Required]
        public int ColorId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "La descripción del color es demasiado larga.")]
        public string Descripcion { get; set; }
    }
}