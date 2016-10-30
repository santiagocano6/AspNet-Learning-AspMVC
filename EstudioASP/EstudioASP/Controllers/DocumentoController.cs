using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstudioASP.Models;
using System.Web.Security;

namespace EstudioASP.Controllers
{
    public class DocumentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult _ObtenerLosUltimosCargados()
        {
            var documentoModels = db.DocumentoModels.Include(d => d.IdiomaModels).Include(d => d.PaisModels).Include(d => d.UniversidadModels).
                OrderByDescending(x => x.FechaCreacion).Take(100);

            //return View(documentoModels.ToList(), "DocumentoModels");
            return View();
        }

        // GET: Documento
        public ActionResult Index(string filtroBusqueda)
        {
            if (filtroBusqueda == null || filtroBusqueda == string.Empty)
            {
                var documentoModels =
                db.DocumentoModels.Include(d => d.IdiomaModels)
                .Include(d => d.PaisModels)
                .Include(d => d.UniversidadModels);

                return View(documentoModels.ToList());
            }
            else
            {
                var documentoModels =
                db.DocumentoModels.Include(d => d.IdiomaModels)
                .Include(d => d.PaisModels)
                .Include(d => d.UniversidadModels)
                .Where(d => d.NombreDocumento.Contains(filtroBusqueda));

                return View(documentoModels.ToList());
            }
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

            string aux = documentoModels.Descripcion;

            return View(documentoModels);
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre");
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre");
            ViewBag.UniversidadID = new SelectList(db.UniversidadModels, "UniversidadID", "Nombre");
            return View();
        }

        // POST: Documento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentoId,NombreDocumento,Materia,CalificacionDocumento,CalidadDocumento,FechaDocumento,FechaCreacion,PaisID,IdiomaID,UniversidadID,ApplicationUserID,Descripcion,Link")] DocumentoModels documentoModels)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    documentoModels.ApplicationUserID = (Guid)Membership.GetUser().ProviderUserKey;
                }
                documentoModels.FechaCreacion = DateTime.Now;

                db.DocumentoModels.Add(documentoModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre", documentoModels.IdiomaID);
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre", documentoModels.PaisID);
            ViewBag.UniversidadID = new SelectList(db.UniversidadModels, "UniversidadID", "Nombre", documentoModels.UniversidadID);
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
            ViewBag.UniversidadID = new SelectList(db.UniversidadModels, "UniversidadID", "Nombre", documentoModels.UniversidadID);
            return View(documentoModels);
        }

        // POST: Documento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentoId,NombreDocumento,Materia,CalificacionDocumento,CalidadDocumento,FechaDocumento,FechaCreacion,PaisID,IdiomaID,UniversidadID,ApplicationUserID,Descripcion,Link")] DocumentoModels documentoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentoModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdiomaID = new SelectList(db.IdiomaModels, "IdiomaID", "Nombre", documentoModels.IdiomaID);
            ViewBag.PaisID = new SelectList(db.PaisModels, "PaisID", "Nombre", documentoModels.PaisID);
            ViewBag.UniversidadID = new SelectList(db.UniversidadModels, "UniversidadID", "Nombre", documentoModels.UniversidadID);
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
