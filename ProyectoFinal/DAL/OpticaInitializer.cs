using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProyectoFinal.Models;

namespace ProyectoFinal.DAL
{
    public class OpticaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OpticaContext>
    {
        protected override void Seed(OpticaContext context)
        {
            var anteojos = new List<Anteojo>
            {
                new Anteojo{AnteojoId=1,ProductoId=0001,NombreModelo="Franks", TamañoId=1, EstiloId=1, ColorId=1 },
                new Anteojo{AnteojoId=2,ProductoId=0002,NombreModelo="Benj", TamañoId=2, EstiloId=2, ColorId=2 },
                new Anteojo{AnteojoId=3,ProductoId=0003,NombreModelo="Kaz", TamañoId=3, EstiloId=3, ColorId=3 }
            };
            anteojos.ForEach(s => context.Anteojos.Add(s));
            context.SaveChanges();

            var clientes = new List<Cliente>
            {
                new Cliente{ClienteId=1,Nombre="Emmanuel",ApellidoPaterno="Villanueva",ApellidoMaterno="Rivera",Telefono="8671269842",CorreoElectronico="emmanuel@correo.com"},
                new Cliente{ClienteId=2,Nombre="Juan",ApellidoPaterno="Perez",ApellidoMaterno="Lopez",Telefono="8671001010",CorreoElectronico="juan@correo.com"},
                new Cliente{ClienteId=3,Nombre="Luis",ApellidoPaterno="Gonzalez",ApellidoMaterno="Reyes",Telefono="8672002020",CorreoElectronico="luis@correo.com"}
            };
            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();

            var colores = new List<Color>
            {
                new Color{ColorId=1,Descripcion="Negro"},
                new Color{ColorId=2,Descripcion="Blanco"},
                new Color{ColorId=3,Descripcion="Transparente"}
            };
            colores.ForEach(s => context.Colores.Add(s));
            context.SaveChanges();

            var estilos = new List<Estilo>
            {
                new Estilo{EstiloId=1,Descripcion="Urbano"},
                new Estilo{EstiloId=2,Descripcion="Geek"},
                new Estilo{EstiloId=3,Descripcion="Clásico"}
            };
            estilos.ForEach(s => context.Estilos.Add(s));
            context.SaveChanges();

            var productos = new List<Producto>
            {
                new Producto{ProductoId=0001,Descripcion="Anteojos",PrecioUnitario=250.00},
                new Producto{ProductoId=0002,Descripcion="Anteojos",PrecioUnitario=350.00},
                new Producto{ProductoId=0003,Descripcion="Anteojos",PrecioUnitario=520.00},
                new Producto{ProductoId=0004,Descripcion="Microfibra",PrecioUnitario=20.00},
                new Producto{ProductoId=0005,Descripcion="Solución limpiadora", PrecioUnitario=60.00}
            };
            productos.ForEach(s => context.Productos.Add(s));
            context.SaveChanges();

            var suscripciones = new List<Suscripcion>
            {
                
            };
            suscripciones.ForEach(s => context.Suscripiones.Add(s));
            context.SaveChanges();

            var tamaños = new List<Tamaño>
            {
                new Tamaño{TamañoId=1,Descripcion="Pequeño"},
                new Tamaño{TamañoId=2,Descripcion="Mediano"},
                new Tamaño{TamañoId=3,Descripcion="Grande"}
            };
            tamaños.ForEach(s => context.Tamaños.Add(s));
            context.SaveChanges();

            var usuarios = new List<Usuario>
            {
                new Usuario{UsuarioId=1,NombreUsuario="admin",Contraseña="password"}
            };
            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

            var ventas = new List<Venta>
            {
                new Venta{VentaId=1,ClienteId=1,UsuarioId=1,Fecha=DateTime.Now},
            };
            ventas.ForEach(s => context.Ventas.Add(s));
            context.SaveChanges();

            var ventaproductos = new List<VentaProducto>
            {
                new VentaProducto{VentaProductoId=1,VentaId=1,ProductoId=1,Cantidad=2}
            };
            ventaproductos.ForEach(s => context.VentaProductos.Add(s));
        }
    }
}