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
    public class FaltasController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Faltas
        public ActionResult Index()
        {
            return View(db.Falta.Include("jogo").Include("jogador").Include("time").ToList());
        }

        // GET: Faltas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falta falta = db.Falta.Find(id);
            if (falta == null)
            {
                return HttpNotFound();
            }
            return View(falta);
        }

        // GET: Faltas/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Faltas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] Falta falta, int time, int jogador, int jogo)
        {
            falta.jogo = db.Jogo.First(a => a.id == jogo);
            falta.jogador = db.Jogador.First(a => a.id == jogador);
            falta.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Falta.Add(falta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(falta);
        }

        // GET: Faltas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falta falta = db.Falta.Find(id);
            if (falta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(falta);
        }

        // POST: Faltas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] Falta falta, int time, int jogador, int jogo)
        {
            falta.jogo = db.Jogo.First(a => a.id == jogo);
            falta.jogador = db.Jogador.First(a => a.id == jogador);
            falta.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(falta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(falta);
        }

        // GET: Faltas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falta falta = db.Falta.Find(id);
            if (falta == null)
            {
                return HttpNotFound();
            }
            return View(falta);
        }

        // POST: Faltas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Falta falta = db.Falta.Find(id);
            db.Falta.Remove(falta);
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
