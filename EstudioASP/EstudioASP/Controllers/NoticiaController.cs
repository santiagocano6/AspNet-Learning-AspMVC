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
    public class NoticiaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult _NoticialPartial()
        {
            return View(db.NoticiaModels.ToList());
        }

        // GET: Noticia
        public ActionResult Index()
        {
            return View(db.NoticiaModels.ToList());
        }

        // GET: Noticia/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticiaModels noticiaModels = db.NoticiaModels.Find(id);
            if (noticiaModels == null)
            {
                return HttpNotFound();
            }
            return View(noticiaModels);
        }

        // GET: Noticia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Noticia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoticiaID,TituloNoticia,DetalleNoticia,RutaImagen,Publico")] NoticiaModels noticiaModels)
        {
            if (ModelState.IsValid)
            {
                noticiaModels.NoticiaID = Guid.NewGuid();
                db.NoticiaModels.Add(noticiaModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noticiaModels);
        }

        // GET: Noticia/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticiaModels noticiaModels = db.NoticiaModels.Find(id);
            if (noticiaModels == null)
            {
                return HttpNotFound();
            }
            return View(noticiaModels);
        }

        // POST: Noticia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoticiaID,TituloNoticia,DetalleNoticia,RutaImagen,Publico")] NoticiaModels noticiaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticiaModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noticiaModels);
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticiaModels noticiaModels = db.NoticiaModels.Find(id);
            if (noticiaModels == null)
            {
                return HttpNotFound();
            }
            return View(noticiaModels);
        }

        // POST: Noticia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NoticiaModels noticiaModels = db.NoticiaModels.Find(id);
            db.NoticiaModels.Remove(noticiaModels);
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
