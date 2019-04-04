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
    public class EscalacaoController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Escalacaos
        public ActionResult Index()
        {
            return View(db.Escalacao.Include("jogo").Include("jogador").Include("time").ToList());
        }

        // GET: Escalacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalacao escalacao = db.Escalacao.Find(id);
            if (escalacao == null)
            {
                return HttpNotFound();
            }
            return View(escalacao);
        }

        // GET: Escalacaos/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Escalacaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,posicao")] Escalacao escalacao, int time, int jogador, int jogo)
        {
            escalacao.jogo = db.Jogo.First(a => a.id == jogo);
            escalacao.jogador = db.Jogador.First(a => a.id == jogador);
            escalacao.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Escalacao.Add(escalacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escalacao);
        }

        // GET: Escalacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalacao escalacao = db.Escalacao.Find(id);
            if (escalacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Jogador = db.Jogador.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(escalacao);
        }

        // POST: Escalacaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,posicao")] Escalacao escalacao, int time, int jogador, int jogo)
        {
            escalacao.jogo = db.Jogo.First(a => a.id == jogo);
            escalacao.jogador = db.Jogador.First(a => a.id == jogador);
            escalacao.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(escalacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escalacao);
        }

        // GET: Escalacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalacao escalacao = db.Escalacao.Find(id);
            if (escalacao == null)
            {
                return HttpNotFound();
            }
            return View(escalacao);
        }

        // POST: Escalacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escalacao escalacao = db.Escalacao.Find(id);
            db.Escalacao.Remove(escalacao);
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
