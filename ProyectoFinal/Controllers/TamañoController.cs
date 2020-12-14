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
    public class TamañoController : Controller
    {
        private OpticaContext db = new OpticaContext();

        // GET: Tamaño
        public ActionResult Index()
        {
            return View(db.Tamaños.ToList());
        }

        // GET: Tamaño/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamaño tamaño = db.Tamaños.Find(id);
            if (tamaño == null)
            {
                return HttpNotFound();
            }
            return View(tamaño);
        }

        // GET: Tamaño/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamaño/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TamañoId,Descripcion")] Tamaño tamaño)
        {
            if (ModelState.IsValid)
            {
                db.Tamaños.Add(tamaño);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamaño);
        }

        // GET: Tamaño/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamaño tamaño = db.Tamaños.Find(id);
            if (tamaño == null)
            {
                return HttpNotFound();
            }
            return View(tamaño);
        }

        // POST: Tamaño/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TamañoId,Descripcion")] Tamaño tamaño)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamaño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamaño);
        }

        // GET: Tamaño/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamaño tamaño = db.Tamaños.Find(id);
            if (tamaño == null)
            {
                return HttpNotFound();
            }
            return View(tamaño);
        }

        // POST: Tamaño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamaño tamaño = db.Tamaños.Find(id);
            db.Tamaños.Remove(tamaño);
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
