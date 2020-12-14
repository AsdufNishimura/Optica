using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Estilo
    {
        [Key]
        [Required]
        public int EstiloId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "La descripción del estilo es demasiado larga.")]
        public string Descripcion { get; set; }
    }
}