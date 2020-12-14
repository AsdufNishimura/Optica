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
    public class AnteojoController : Controller
    {
        private OpticaContext db = new OpticaContext();

        // GET: Anteojo
        public ActionResult Index()
        {
            var anteojos = db.Anteojos.Include(a => a.Color).Include(a => a.Estilo).Include(a => a.Producto).Include(a => a.Tamaño);
            return View(anteojos.ToList());
        }

        // GET: Anteojo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anteojo anteojo = db.Anteojos.Find(id);
            if (anteojo == null)
            {
                return HttpNotFound();
            }
            return View(anteojo);
        }

        // GET: Anteojo/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colores, "ColorId", "Descripcion");
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion");
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion");
            return View();
        }

        // POST: Anteojo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnteojoId,ProductoId,NombreModelo,TamañoId,EstiloId,ColorId")] Anteojo anteojo)
        {
            if (ModelState.IsValid)
            {
                db.Anteojos.Add(anteojo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colores, "ColorId", "Descripcion", anteojo.ColorId);
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", anteojo.EstiloId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", anteojo.ProductoId);
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion", anteojo.TamañoId);
            return View(anteojo);
        }

        // GET: Anteojo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anteojo anteojo = db.Anteojos.Find(id);
            if (anteojo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colores, "ColorId", "Descripcion", anteojo.ColorId);
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", anteojo.EstiloId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", anteojo.ProductoId);
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion", anteojo.TamañoId);
            return View(anteojo);
        }

        // POST: Anteojo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnteojoId,ProductoId,NombreModelo,TamañoId,EstiloId,ColorId")] Anteojo anteojo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anteojo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colores, "ColorId", "Descripcion", anteojo.ColorId);
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "Descripcion", anteojo.EstiloId);
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", anteojo.ProductoId);
            ViewBag.TamañoId = new SelectList(db.Tamaños, "TamañoId", "Descripcion", anteojo.TamañoId);
            return View(anteojo);
        }

        // GET: Anteojo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anteojo anteojo = db.Anteojos.Find(id);
            if (anteojo == null)
            {
                return HttpNotFound();
            }
            return View(anteojo);
        }

        // POST: Anteojo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anteojo anteojo = db.Anteojos.Find(id);
            db.Anteojos.Remove(anteojo);
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
