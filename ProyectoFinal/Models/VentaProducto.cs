using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class VentaProducto
    {
        [Key]
        [Required]
        public int VentaProductoId { get; set; }

        [Required]
        public int VentaId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public double Cantidad { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get { return Cantidad * Producto.PrecioUnitario; } }


        [ForeignKey("VentaId")]
        public virtual Venta Venta { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }
        
    }
}