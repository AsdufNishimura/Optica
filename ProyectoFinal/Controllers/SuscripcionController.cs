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
    public class SuscripcionController : Controller
    {
        private OpticaContext db = new OpticaContext();

        // GET: Suscripcion
        public ActionResult Index()
        {
            var suscripiones = db.Suscripiones.Include(s => s.Cliente).Include(s => s.Estilo).Include(s => s.Producto).Include(s => s.Tamaño);
            return View(suscripiones.ToList());
        }

        // GET: Suscripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripcion suscripcion = db.Suscripiones.Find(id);
            if (suscripcion == null)
            {
                return HttpNotFound();
            }
            return View(suscripcion);
        }

        // GET: Suscripcion/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre");
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion");
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion");
            return View();
        }

        // POST: Suscripcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuscripcionId,ClienteId,ProductoId,TamañoId,EstiloId")] Suscripcion suscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Suscripiones.Add(suscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", suscripcion.ClienteId);
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", suscripcion.EstiloId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", suscripcion.ProductoId);
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion", suscripcion.TamañoId);
            return View(suscripcion);
        }

        // GET: Suscripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripcion suscripcion = db.Suscripiones.Find(id);
            if (suscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", suscripcion.ClienteId);
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", suscripcion.EstiloId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", suscripcion.ProductoId);
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion", suscripcion.TamañoId);
            return View(suscripcion);
        }

        // POST: Suscripcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuscripcionId,ClienteId,ProductoId,TamañoId,EstiloId")] Suscripcion suscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", suscripcion.ClienteId);
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", suscripcion.EstiloId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", suscripcion.ProductoId);
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion", suscripcion.TamañoId);
            return View(suscripcion);
        }

        // GET: Suscripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suscripcion suscripcion = db.Suscripiones.Find(id);
            if (suscripcion == null)
            {
                return HttpNotFound();
            }
            return View(suscripcion);
        }

        // POST: Suscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suscripcion suscripcion = db.Suscripiones.Find(id);
            db.Suscripiones.Remove(suscripcion);
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
