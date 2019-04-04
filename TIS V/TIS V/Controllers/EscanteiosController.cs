using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contexto;
using TISV.Models;

namespace TIS_V.Controllers
{
    public class EscanteiosController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Escanteios
        public ActionResult Index()
        {
            return View(db.Escanteio.Include("jogo").Include("time").ToList());
        }

        // GET: Escanteios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escanteio escanteio = db.Escanteio.Find(id);
            if (escanteio == null)
            {
                return HttpNotFound();
            }
            return View(escanteio);
        }

        // GET: Escanteios/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Escanteios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] Escanteio escanteio, int jogo, int time)
        {
            escanteio.jogo = db.Jogo.First(a => a.id == jogo);
            escanteio.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Escanteio.Add(escanteio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escanteio);
        }

        // GET: Escanteios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escanteio escanteio = db.Escanteio.Find(id);
            if (escanteio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(escanteio);
        }

        // POST: Escanteios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] Escanteio escanteio, int jogo, int time)
        {
            escanteio.jogo = db.Jogo.First(a => a.id == jogo);
            escanteio.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(escanteio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escanteio);
        }

        // GET: Escanteios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escanteio escanteio = db.Escanteio.Find(id);
            if (escanteio == null)
            {
                return HttpNotFound();
            }
            return View(escanteio);
        }

        // POST: Escanteios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escanteio escanteio = db.Escanteio.Find(id);
            db.Escanteio.Remove(escanteio);
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
