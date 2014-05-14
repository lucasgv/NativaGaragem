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
    public class FuncionarioController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Funcionario/

        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.Usuario);
            return View(funcionarios.ToList());
        }

        //
        // GET: /Funcionario/Details/5

        public ActionResult Details(long id = 0)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Create

        public ActionResult Create()
        {
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nome");
            return View();
        }

        //
        // POST: /Funcionario/Create

        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nome", funcionario.IDUsuario);
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nome", funcionario.IDUsuario);
            return View(funcionario);
        }

        //
        // POST: /Funcionario/Edit/5

        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUsuario = new SelectList(db.Usuarios, "IDUsuario", "Nome", funcionario.IDUsuario);
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // POST: /Funcionario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
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