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
    public class JogosController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Jogos
        public ActionResult Index()
        {
            return View(db.Jogo.Include("mandante").Include("visitante").ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogo.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            ViewBag.Lista = db.Equipes.ToList();
            return View();
        }

        // POST: Jogos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,data")] Jogo jogo, int mandante, int visitante)
        {
            jogo.mandante = db.Equipes.First(a => a.id == mandante);
            jogo.visitante = db.Equipes.First(a => a.id == visitante);
            if (ModelState.IsValid)
            {
                db.Jogo.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogo.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lista = db.Equipes.ToList();
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,data")] Jogo jogo, int mandante, int visitante)
        {
            jogo.mandante = db.Equipes.First(a => a.id == mandante);
            jogo.visitante = db.Equipes.First(a => a.id == visitante);
            if (ModelState.IsValid)
            {
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogo.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogo.Find(id);
            db.Jogo.Remove(jogo);
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
