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
    public class LimpezaController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Limpeza/

        public ActionResult Index()
        {
            return View(db.Limpezas.ToList());
        }

        //
        // GET: /Limpeza/Details/5

        public ActionResult Details(long id = 0)
        {
            Limpeza limpeza = db.Limpezas.Find(id);
            if (limpeza == null)
            {
                return HttpNotFound();
            }
            return View(limpeza);
        }

        //
        // GET: /Limpeza/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Limpeza/Create

        [HttpPost]
        public ActionResult Create(Limpeza limpeza)
        {
            if (ModelState.IsValid)
            {
                db.Limpezas.Add(limpeza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(limpeza);
        }

        //
        // GET: /Limpeza/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Limpeza limpeza = db.Limpezas.Find(id);
            if (limpeza == null)
            {
                return HttpNotFound();
            }
            return View(limpeza);
        }

        //
        // POST: /Limpeza/Edit/5

        [HttpPost]
        public ActionResult Edit(Limpeza limpeza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(limpeza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(limpeza);
        }

        //
        // GET: /Limpeza/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Limpeza limpeza = db.Limpezas.Find(id);
            if (limpeza == null)
            {
                return HttpNotFound();
            }
            return View(limpeza);
        }

        //
        // POST: /Limpeza/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Limpeza limpeza = db.Limpezas.Find(id);
            db.Limpezas.Remove(limpeza);
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