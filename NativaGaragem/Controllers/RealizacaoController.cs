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
    public class RealizacaoController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Realizacao/

        public ActionResult Index()
        {
            var realizacoes = db.Realizacoes.Include(r => r.Funcionario).Include(r => r.Limpeza);
            return View(realizacoes.ToList());
        }

        //
        // GET: /Realizacao/Details/5

        public ActionResult Details(long id = 0)
        {
            Realizacao realizacao = db.Realizacoes.Find(id);
            if (realizacao == null)
            {
                return HttpNotFound();
            }
            return View(realizacao);
        }

        //
        // GET: /Realizacao/Create

        public ActionResult Create()
        {
            ViewBag.IDFuncionario = new SelectList(db.Funcionarios, "IDFuncionario", "Categoria");
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo");
            return View();
        }

        //
        // POST: /Realizacao/Create

        [HttpPost]
        public ActionResult Create(Realizacao realizacao)
        {
            if (ModelState.IsValid)
            {
                db.Realizacoes.Add(realizacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFuncionario = new SelectList(db.Funcionarios, "IDFuncionario", "Categoria", realizacao.IDFuncionario);
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo", realizacao.IDLimpeza);
            return View(realizacao);
        }

        //
        // GET: /Realizacao/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Realizacao realizacao = db.Realizacoes.Find(id);
            if (realizacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFuncionario = new SelectList(db.Funcionarios, "IDFuncionario", "Categoria", realizacao.IDFuncionario);
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo", realizacao.IDLimpeza);
            return View(realizacao);
        }

        //
        // POST: /Realizacao/Edit/5

        [HttpPost]
        public ActionResult Edit(Realizacao realizacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realizacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFuncionario = new SelectList(db.Funcionarios, "IDFuncionario", "Categoria", realizacao.IDFuncionario);
            ViewBag.IDLimpeza = new SelectList(db.Limpezas, "IDLimpeza", "Tipo", realizacao.IDLimpeza);
            return View(realizacao);
        }

        //
        // GET: /Realizacao/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Realizacao realizacao = db.Realizacoes.Find(id);
            if (realizacao == null)
            {
                return HttpNotFound();
            }
            return View(realizacao);
        }

        //
        // POST: /Realizacao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Realizacao realizacao = db.Realizacoes.Find(id);
            db.Realizacoes.Remove(realizacao);
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