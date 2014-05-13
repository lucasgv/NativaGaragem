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
    public class GaragemController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Garagem/

        public ActionResult Index()
        {
            return View(db.Garagens.ToList());
        }

        //
        // GET: /Garagem/Details/5

        public ActionResult Details(long id = 0)
        {
            Garagem garagem = db.Garagens.Find(id);
            if (garagem == null)
            {
                return HttpNotFound();
            }
            return View(garagem);
        }

        //
        // GET: /Garagem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Garagem/Create

        [HttpPost]
        public ActionResult Create(Garagem garagem)
        {
            if (ModelState.IsValid)
            {
                db.Garagens.Add(garagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garagem);
        }

        //
        // GET: /Garagem/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Garagem garagem = db.Garagens.Find(id);
            if (garagem == null)
            {
                return HttpNotFound();
            }
            return View(garagem);
        }

        //
        // POST: /Garagem/Edit/5

        [HttpPost]
        public ActionResult Edit(Garagem garagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garagem);
        }

        //
        // GET: /Garagem/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Garagem garagem = db.Garagens.Find(id);
            if (garagem == null)
            {
                return HttpNotFound();
            }
            return View(garagem);
        }

        //
        // POST: /Garagem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Garagem garagem = db.Garagens.Find(id);
            db.Garagens.Remove(garagem);
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