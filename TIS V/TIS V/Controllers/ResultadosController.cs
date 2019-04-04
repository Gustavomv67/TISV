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
    public class ResultadosController : Controller
    {
        private TIS_VContext db = new TIS_VContext();

        // GET: Resultadoes
        public ActionResult Index()
        {
            return View(db.Resultado.Include("jogo").Include("time").ToList());
        }

        // GET: Resultadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultado.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // GET: Resultadoes/Create
        public ActionResult Create()
        {
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View();
        }

        // POST: Resultadoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,gols1,gols2,posse1,posse2")] Resultado resultado, int time, int jogo)
        {
            resultado.jogo = db.Jogo.First(a => a.id == jogo);
            resultado.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Resultado.Add(resultado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultado);
        }

        // GET: Resultadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultado.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jogo = db.Jogo.ToList();
            ViewBag.Equipe = db.Equipes.ToList();
            return View(resultado);
        }

        // POST: Resultadoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,gols1,gols2,posse1,posse2")] Resultado resultado, int time, int jogo)
        {
            resultado.jogo = db.Jogo.First(a => a.id == jogo);
            resultado.time = db.Equipes.First(a => a.id == time);
            if (ModelState.IsValid)
            {
                db.Entry(resultado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultado);
        }

        // GET: Resultadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultado.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // POST: Resultadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultado resultado = db.Resultado.Find(id);
            db.Resultado.Remove(resultado);
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
