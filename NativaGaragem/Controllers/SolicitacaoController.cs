using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NativaGaragem.Models;

namespace NativaGaragem.Controllers
{
    public class SolicitacaoController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Solicitacao/

        public ActionResult Index()
        {
            var solicitacoes = db.Solicitacoes.Include(s => s.Carro).Include(s => s.Limpeza);
            return View(solicitacoes.ToList());
        }

        //
        // GET: /Solicitacao/Details/5

        public ActionResult Details(long id = 0)
        {
            Solicitacao solicitacao = db.Solicitacoes.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        //
        // GET: /Solicitacao/Create

        public ActionResult Create()
        {
            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo");
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo");
            return View();
        }

        //
        // POST: /Solicitacao/Create

        [HttpPost]
        public ActionResult Create(Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Solicitacoes.Add(solicitacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo", solicitacao.IDCarro);
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo", solicitacao.IDLimpeza);
            return View(solicitacao);
        }

        //
        // GET: /Solicitacao/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Solicitacao solicitacao = db.Solicitacoes.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo", solicitacao.IDCarro);
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo", solicitacao.IDLimpeza);
            return View(solicitacao);
        }

        //
        // POST: /Solicitacao/Edit/5

        [HttpPost]
        public ActionResult Edit(Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo", solicitacao.IDCarro);
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo", solicitacao.IDLimpeza);
            return View(solicitacao);
        }

        //
        // GET: /Solicitacao/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Solicitacao solicitacao = db.Solicitacoes.Find(id);
            if (solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(solicitacao);
        }

        //
        // POST: /Solicitacao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Solicitacao solicitacao = db.Solicitacoes.Find(id);
            db.Solicitacoes.Remove(solicitacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}