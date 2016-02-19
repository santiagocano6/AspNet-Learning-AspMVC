﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using EstudioASP.Models;

//namespace EstudioASP.Controllers
//{
//    public class NewsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: News
//        public async Task<ActionResult> _NewsPartial()
//        {
//            return View(await db.NewsModels.ToListAsync());
//        }

//        // GET: News
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.NewsModels.ToListAsync());
//        }

//        // GET: News/Details/5
//        public async Task<ActionResult> Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NewsModels newsModels = await db.NewsModels.FindAsync(id);
//            if (newsModels == null)
//            {
//                return HttpNotFound();
//            }
//            return View(newsModels);
//        }

//        // GET: News/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: News/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "NoticiaID,TituloNoticia,DetalleNoticia,RutaImagen")] NewsModels newsModels)
//        {
//            if (ModelState.IsValid)
//            {
//                newsModels.NoticiaID = Guid.NewGuid();
//                db.NewsModels.Add(newsModels);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(newsModels);
//        }

//        // GET: News/Edit/5
//        public async Task<ActionResult> Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NewsModels newsModels = await db.NewsModels.FindAsync(id);
//            if (newsModels == null)
//            {
//                return HttpNotFound();
//            }
//            return View(newsModels);
//        }

//        // POST: News/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "NoticiaID,TituloNoticia,DetalleNoticia,RutaImagen")] NewsModels newsModels)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(newsModels).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(newsModels);
//        }

//        // GET: News/Delete/5
//        public async Task<ActionResult> Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NewsModels newsModels = await db.NewsModels.FindAsync(id);
//            if (newsModels == null)
//            {
//                return HttpNotFound();
//            }
//            return View(newsModels);
//        }

//        // POST: News/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(Guid id)
//        {
//            NewsModels newsModels = await db.NewsModels.FindAsync(id);
//            db.NewsModels.Remove(newsModels);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
