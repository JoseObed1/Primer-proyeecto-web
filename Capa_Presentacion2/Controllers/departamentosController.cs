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
    [Authorize]
    public class departamentosController : Controller
    {
        private BDPEntities db = new BDPEntities();
        private NegocioDepartamentos ng = new NegocioDepartamentos();

        // GET: departamentos
        public ActionResult Index()
        {
            return View(ng.MostrarDatos());
        }

        // GET: departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamentos departamentos = db.departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
        }

        // GET: departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dept,nombre,sigla")] departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                ng.GuardarDepartamentos(departamentos);
                return RedirectToAction("Index");
            }

            return View(departamentos);
        }

        // GET: departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamentos departamentos = db.departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
        }

        // POST: departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dept,nombre,sigla")] departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                ng.EditDepartamentos(departamentos);
                return RedirectToAction("Index");
            }
            return View(departamentos);
        }

        // GET: departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamentos departamentos = db.departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
        }

        // POST: departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ng.DeletedDepartamentos(id);
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
