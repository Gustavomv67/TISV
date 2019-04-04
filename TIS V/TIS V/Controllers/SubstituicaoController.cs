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
    public class SubstituicaoController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Subtituicao
        public ActionResult Index()
        {
            return View(db.Subtituicao.Include("jogo").Include("jogadorEntrou").Include("jogadorSaiu").Include("time").ToList());
        }

        // GET: Subtituicao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtituicao subtituicao = db.Subtituicao.Find(id);
            if (subtituicao == null)
            {
                return HttpNotFound();
            }
            return View(subtituicao);
        }

        // GET: Subtituicao/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Subtituicao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] Subtituicao subtituicao, int time, int jogadorEntrou, int jogadorSaiu, int jogo)
        {
            subtituicao.jogo = db.Jogo.First(a => a.id == jogo);
            subtituicao.jogadorEntrou = db.Jogador.First(a => a.id == jogadorEntrou);
            subtituicao.jogadorSaiu = db.Jogador.First(a => a.id == jogadorSaiu);
            subtituicao.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Subtituicao.Add(subtituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subtituicao);
        }

        // GET: Subtituicao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtituicao subtituicao = db.Subtituicao.Find(id);
            if (subtituicao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(subtituicao);
        }

        // POST: Subtituicao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] Subtituicao subtituicao, int time, int jogadorEntrou, int jogadorSaiu, int jogo)
        {
            subtituicao.jogo = db.Jogo.First(a => a.id == jogo);
            subtituicao.jogadorEntrou = db.Jogador.First(a => a.id == jogadorEntrou);
            subtituicao.jogadorSaiu = db.Jogador.First(a => a.id == jogadorSaiu);
            subtituicao.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(subtituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subtituicao);
        }

        // GET: Subtituicao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subtituicao subtituicao = db.Subtituicao.Find(id);
            if (subtituicao == null)
            {
                return HttpNotFound();
            }
            return View(subtituicao);
        }

        // POST: Subtituicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subtituicao subtituicao = db.Subtituicao.Find(id);
            db.Subtituicao.Remove(subtituicao);
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
