using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;

namespace Capa_Presentacion2.Controllers
{
    public class cuentasController : Controller
    {
        private BDPEntities db = new BDPEntities();
        private NegocioCuentas ng = new NegocioCuentas();

        // GET: cuentas
        public ActionResult Index()
        {
            return View(ng.MostrarDatos());
        }

        // GET: cuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentas cuentas = db.cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // GET: cuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuenta,nombre,correo,pass")] cuentas cuentas)
        {
            
            if (ModelState.IsValid)
            {
                if (db.cuentas.Any(x => x.correo == cuentas.correo))
                {
                    ViewBag.Notification = "Esta cuenta ya existe";
                }
                else
                {
                    ng.GuardarCuentas(cuentas);
                    Session["UserName"] = cuentas.nombre.ToString();
                    return RedirectToAction("Index", "documentoes");
                }
            }

            return View(cuentas);
        }

        // GET: cuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentas cuentas = db.cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // POST: cuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuenta,nombre,correo,pass")] cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                ng.EditCuentas(cuentas);
                return RedirectToAction("Index");
            }
            return View(cuentas);
        }

        // GET: cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentas cuentas = db.cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // POST: cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ng.DeletedCuentas(id);
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
