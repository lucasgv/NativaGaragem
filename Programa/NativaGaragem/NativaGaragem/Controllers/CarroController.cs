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
    public class CarroController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Carro/

        public ActionResult Index()
        {
            var carros = db.Carros.Include(c => c.Cliente).Include(c => c.Garagem);
            return View(carros.ToList());
        }

        //
        // GET: /Carro/Details/5

        public ActionResult Details(long id = 0)
        {
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        //
        // GET: /Carro/Create

        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco");
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome");
            return View();
        }

        //
        // POST: /Carro/Create

        [HttpPost]
        public ActionResult Create(Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Carros.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco", carro.IDCliente);
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome", carro.IDGaragem);
            return View(carro);
        }

        //
        // GET: /Carro/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco", carro.IDCliente);
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome", carro.IDGaragem);
            return View(carro);
        }

        //
        // POST: /Carro/Edit/5

        [HttpPost]
        public ActionResult Edit(Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco", carro.IDCliente);
            ViewBag.IDGaragem = new SelectList(db.Garagens, "IDGaragem", "Nome", carro.IDGaragem);
            return View(carro);
        }

        //
        // GET: /Carro/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Carro carro = db.Carros.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        //
        // POST: /Carro/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Carro carro = db.Carros.Find(id);
            db.Carros.Remove(carro);
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