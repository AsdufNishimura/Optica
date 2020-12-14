using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Venta
    {
        public Venta()
        {
            this.VentaProductos = new HashSet<VentaProducto>();
        }

        [Key]
        [Required]
        public int VentaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Fecha { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total
        {
            get
            {
                double t = 0;
                foreach (VentaProducto vp in VentaProductos)
                {
                    t += vp.Subtotal;
                }
                return t;
            }
        }
        
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("VentaProductoId")]
        public virtual ICollection<VentaProducto> VentaProductos { get; set; }
    }
}