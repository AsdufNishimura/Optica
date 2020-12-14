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
    public class EstiloController : Controller
    {
        private OpticaContext db = new OpticaContext();

        // GET: Estilo
        public ActionResult Index()
        {
            return View(db.Estilos.ToList());
        }

        // GET: Estilo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilos.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // GET: Estilo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estilo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstiloId,Descripcion")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Estilos.Add(estilo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estilo);
        }

        // GET: Estilo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilos.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // POST: Estilo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstiloId,Descripcion")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estilo);
        }

        // GET: Estilo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilos.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // POST: Estilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estilo estilo = db.Estilos.Find(id);
            db.Estilos.Remove(estilo);
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
