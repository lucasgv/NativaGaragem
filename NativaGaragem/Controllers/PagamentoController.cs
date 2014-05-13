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
    public class PagamentoController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Pagamento/

        public ActionResult Index()
        {
            var pagamentos = db.Pagamentos.Include(p => p.Cliente);
            return View(pagamentos.ToList());
        }

        //
        // GET: /Pagamento/Details/5

        public ActionResult Details(long id = 0)
        {
            Pagamento pagamento = db.Pagamentos.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        //
        // GET: /Pagamento/Create

        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco");
            return View();
        }

        //
        // POST: /Pagamento/Create

        [HttpPost]
        public ActionResult Create(Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Pagamentos.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco", pagamento.IDCliente);
            return View(pagamento);
        }

        //
        // GET: /Pagamento/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Pagamento pagamento = db.Pagamentos.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco", pagamento.IDCliente);
            return View(pagamento);
        }

        //
        // POST: /Pagamento/Edit/5

        [HttpPost]
        public ActionResult Edit(Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Endereco", pagamento.IDCliente);
            return View(pagamento);
        }

        //
        // GET: /Pagamento/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Pagamento pagamento = db.Pagamentos.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }

        //
        // POST: /Pagamento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Pagamento pagamento = db.Pagamentos.Find(id);
            db.Pagamentos.Remove(pagamento);
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