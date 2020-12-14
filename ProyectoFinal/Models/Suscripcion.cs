using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Suscripcion
    {
        [Key]
        [Required]
        public int SuscripcionId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public int ProductoId { get; set; }

        public int TamañoId { get; set; }

        public int EstiloId { get; set; }


        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        [ForeignKey("TamañoId")]
        public virtual Tamaño Tamaño { get; set; }

        [ForeignKey("EstiloId")]
        public virtual Estilo Estilo { get; set; }
    }
}