using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class VentaController : Controller
    {
        private OpticaContext db = new OpticaContext();

        // GET: Venta
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Cliente).Include(v => v.Usuario);

            
            //    var clientes = db.Clientes.ToList();
            //    var clienteItems = new List<SelectListItem>();
            //    foreach (var item in clientes)
            //    {
            //        clienteItems.Add(new SelectListItem
            //        {
            //            Text = item.NombreCompleto,
            //            Value = item.ClienteId.ToString()
            //        });
            //    }
            //    ViewBag.clienteItems = clienteItems;

            //var usuarios = db.Usuarios.ToList();
            //var usuarioItems = new List<SelectListItem>();
            //foreach (var item in usuarios)
            //{
            //    usuarioItems.Add(new SelectListItem
            //    {
            //        Text = item.NombreUsuario,
            //        Value = item.UsuarioId.ToString()
            //    });
            //}
            //ViewBag.usuarioItems = usuarioItems;

            return View(ventas.ToList());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            //var model = new ProyectoFinal.ViewModels.VentaViewModel
            //{
            //    Venta = new Venta(),
            //    Clientes = new SelectList(this.UnitOfWork.RegionRepository.Get(), "Id", "Name")
            //};
            var clientes = new List<Cliente>();
            clientes = db.Clientes.ToList();

            ViewBag.ClienteId = new SelectList(clientes, "ClienteId", "NombreCompleto");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NombreUsuario");
            return View();
        }

        // POST: Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,ClienteId,UsuarioId,Fecha")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NombreUsuario", venta.UsuarioId);
            return View(venta);
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NombreUsuario", venta.UsuarioId);
            return View(venta);
        }

        // POST: Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,ClienteId,UsuarioId,Fecha")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NombreUsuario", venta.UsuarioId);
            return View(venta);
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Ventas.Find(id);
            db.Ventas.Remove(venta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
