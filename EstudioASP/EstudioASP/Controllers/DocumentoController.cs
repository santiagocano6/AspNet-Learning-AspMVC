using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstudioASP.Models;

namespace EstudioASP.Controllers
{
    public class DocumentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Documento
        public ActionResult Index()
        {
            var documentoModels = db.DocumentoModels.Include(d => d.IdiomaModels).Include(d => d.PaisModels);
            return View(documentoModels.ToList());
        }

        // GET: Documento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentoModels documentoModels = db.DocumentoModels.Find(id);
            if (documentoModels == null)
            {
                return HttpNotFound();
            }
            return View(documentoModels);
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre");
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre");
            return View();
        }

        // POST: Documento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreDocumento,Materia,Universidad,Calificacion,Calidad,FechaDocumento,FechaCreacion,PaisID,IdiomaID")] DocumentoModels documentoModels)
        {
            if (ModelState.IsValid)
            {
                db.DocumentoModels.Add(documentoModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre", documentoModels.IdiomaID);
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre", documentoModels.PaisID);
            return View(documentoModels);
        }

        // GET: Documento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentoModels documentoModels = db.DocumentoModels.Find(id);
            if (documentoModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre", documentoModels.IdiomaID);
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre", documentoModels.PaisID);
            return View(documentoModels);
        }

        // POST: Documento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreDocumento,Materia,Universidad,Calificacion,Calidad,FechaDocumento,FechaCreacion,PaisID,IdiomaID")] DocumentoModels documentoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentoModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre", documentoModels.IdiomaID);
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre", documentoModels.PaisID);
            return View(documentoModels);
        }

        // GET: Documento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentoModels documentoModels = db.DocumentoModels.Find(id);
            if (documentoModels == null)
            {
                return HttpNotFound();
            }
            return View(documentoModels);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentoModels documentoModels = db.DocumentoModels.Find(id);
            db.DocumentoModels.Remove(documentoModels);
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
