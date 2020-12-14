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
    public class VentaProductoController : Controller
    {
        private OpticaContext db = new OpticaContext();

        // GET: VentaProducto
        public ActionResult Index()
        {
            var ventaProductos = db.VentaProductos.Include(v => v.Producto).Include(v => v.Venta);
            return View(ventaProductos.ToList());
        }

        // GET: VentaProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaProducto ventaProducto = db.VentaProductos.Find(id);
            if (ventaProducto == null)
            {
                return HttpNotFound();
            }
            return View(ventaProducto);
        }

        // GET: VentaProducto/Create
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion");
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: VentaProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaProductoId,VentaId,ProductoId,Cantidad")] VentaProducto ventaProducto)
        {
            if (ModelState.IsValid)
            {
                db.VentaProductos.Add(ventaProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", ventaProducto.ProductoId);
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", ventaProducto.VentaId);
            return View(ventaProducto);
        }

        // GET: VentaProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaProducto ventaProducto = db.VentaProductos.Find(id);
            if (ventaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", ventaProducto.ProductoId);
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", ventaProducto.VentaId);
            return View(ventaProducto);
        }

        // POST: VentaProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaProductoId,VentaId,ProductoId,Cantidad")] VentaProducto ventaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoId", "Descripcion", ventaProducto.ProductoId);
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", ventaProducto.VentaId);
            return View(ventaProducto);
        }

        // GET: VentaProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaProducto ventaProducto = db.VentaProductos.Find(id);
            if (ventaProducto == null)
            {
                return HttpNotFound();
            }
            return View(ventaProducto);
        }

        // POST: VentaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaProducto ventaProducto = db.VentaProductos.Find(id);
            db.VentaProductos.Remove(ventaProducto);
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
