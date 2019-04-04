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
    public class GolsController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Gols
        public ActionResult Index()
        {
            return View(db.Gols.Include("jogo").Include("jogador").Include("time").ToList());
        }

        // GET: Gols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gols gols = db.Gols.Find(id);
            if (gols == null)
            {
                return HttpNotFound();
            }
            return View(gols);
        }

        // GET: Gols/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Gols/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,falta,penalti,escanteio")] Gols gols, int time, int jogador, int jogo)
        {
            gols.jogo = db.Jogo.First(a => a.id == jogo);
            gols.jogador = db.Jogador.First(a => a.id == jogador);
            gols.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Gols.Add(gols);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gols);
        }

        // GET: Gols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gols gols = db.Gols.Find(id);
            if (gols == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(gols);
        }

        // POST: Gols/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,falta,penalti,escanteio")] Gols gols, int time, int jogador, int jogo)
        {
            gols.jogo = db.Jogo.First(a => a.id == jogo);
            gols.jogador = db.Jogador.First(a => a.id == jogador);
            gols.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(gols).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gols);
        }

        // GET: Gols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gols gols = db.Gols.Find(id);
            if (gols == null)
            {
                return HttpNotFound();
            }
            return View(gols);
        }

        // POST: Gols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gols gols = db.Gols.Find(id);
            db.Gols.Remove(gols);
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
