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
    public class VagaController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Vaga/

        public ActionResult Index()
        {
            var vagas = db.Vagas.Include(v => v.Carro).Include(v => v.Garagem);
            return View(vagas.ToList());
        }

        //
        // GET: /Vaga/Details/5

        public ActionResult Details(long id = 0)
        {
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        //
        // GET: /Vaga/Create

        public ActionResult Create()
        {
            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo");
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome");
            return View();
        }

        //
        // POST: /Vaga/Create

        [HttpPost]
        public ActionResult Create(Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                db.Vagas.Add(vaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo", vaga.IDCarro);
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome", vaga.IDGaragem);
            return View(vaga);
        }

        //
        // GET: /Vaga/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo", vaga.IDCarro);
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome", vaga.IDGaragem);
            return View(vaga);
        }

        //
        // POST: /Vaga/Edit/5

        [HttpPost]
        public ActionResult Edit(Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCarro = new SelectList(db.Carros, "IDCarro", "Modelo", vaga.IDCarro);
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome", vaga.IDGaragem);
            return View(vaga);
        }

        //
        // GET: /Vaga/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        //
        // POST: /Vaga/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Vaga vaga = db.Vagas.Find(id);
            db.Vagas.Remove(vaga);
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