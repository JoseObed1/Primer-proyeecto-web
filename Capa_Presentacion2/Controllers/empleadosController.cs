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
    public class empleadosController : Controller
    {
        private BDPEntities db = new BDPEntities();
        private NegocioEmpleados ng = new NegocioEmpleados();

        // GET: empleados
        public ActionResult Index()
        {
            return View(ng.MostrarDatos());
        }

        // GET: empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_employe,nombre,departamento,cargo")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                ng.GuardarEmpleados(empleados);
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_employe,nombre,departamento,cargo")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                ng.EditEmpleado(empleados);
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ng.DeletedEmpleado(id);
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
