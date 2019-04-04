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
    public class PenaltisController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Penaltis
        public ActionResult Index()
        {
            return View(db.Penalti.Include("jogo").Include("jogador").Include("time").ToList());
        }

        // GET: Penaltis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalti penalti = db.Penalti.Find(id);
            if (penalti == null)
            {
                return HttpNotFound();
            }
            return View(penalti);
        }

        // GET: Penaltis/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Penaltis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] Penalti penalti, int time, int jogador, int jogo)
        {
            penalti.jogo = db.Jogo.First(a => a.id == jogo);
            penalti.jogador = db.Jogador.First(a => a.id == jogador);
            penalti.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Penalti.Add(penalti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(penalti);
        }

        // GET: Penaltis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalti penalti = db.Penalti.Find(id);
            if (penalti == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(penalti);
        }

        // POST: Penaltis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] Penalti penalti, int time, int jogador, int jogo)
        {
            penalti.jogo = db.Jogo.First(a => a.id == jogo);
            penalti.jogador = db.Jogador.First(a => a.id == jogador);
            penalti.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(penalti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(penalti);
        }

        // GET: Penaltis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalti penalti = db.Penalti.Find(id);
            if (penalti == null)
            {
                return HttpNotFound();
            }
            return View(penalti);
        }

        // POST: Penaltis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Penalti penalti = db.Penalti.Find(id);
            db.Penalti.Remove(penalti);
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
