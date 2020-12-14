using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProyectoFinal.Models;

namespace ProyectoFinal.DAL
{
    public class OpticaContext : DbContext
    {
        public OpticaContext() : base("OpticaContext")
        {

        }

        public DbSet<Anteojo> Anteojos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Suscripcion> Suscripiones { get; set; }
        public DbSet<Tamaño> Tamaños { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentaProductos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}