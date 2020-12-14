using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Tamaño
    {
        [Key]
        [Required]
        public int TamañoId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "La descripción del tamaño es demasiado larga.")]
        public string Descripcion { get; set; }
    }
}