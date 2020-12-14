using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class VentaViewModel
    {
        public Venta Venta { get; set; }
        public int SelectClienteId { get; set; }
        public SelectList Clientes { get; set; }
    }
}