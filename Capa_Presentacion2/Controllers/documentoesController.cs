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
    public class documentoesController : Controller
    {
        private BDPEntities db = new BDPEntities();
        private NegocioDocumentos ng = new NegocioDocumentos();
        private NegocioDepartamentos ng_d = new NegocioDepartamentos();

        // GET: documentoes
        public ActionResult Index()
        {
            return View(ng.MostrarDocumentos());
        }

        // GET: documentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: documentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: documentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_documentos,codigo,empleado,dept_origen,dept_destino,fecha")] documento documento)
        {
            if (ModelState.IsValid)
            {
                documento.fecha = DateTime.Now;
                string siglaOr = ng_d.Sigla(documento.dept_origen).ToString();
                string siglaDest = ng_d.Sigla(documento.dept_destino).ToString();
                documento.codigo = ng.CodeGen(siglaOr, siglaDest);

                System.Diagnostics.Debug.WriteLine(documento.dept_destino);
                System.Diagnostics.Debug.WriteLine(documento.dept_origen);
                System.Diagnostics.Debug.WriteLine(documento.fecha);
                System.Diagnostics.Debug.WriteLine(documento.codigo);

                ng.GuardarDocumentos(documento);
                return RedirectToAction("Index");
            }

            return View(documento);
        }

        // GET: documentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: documentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_documentos,codigo,empleado,dept_origen,dept_destino,fecha")] documento documento)
        {
            if (ModelState.IsValid)
            {
                ng.EditDocumentos(documento);
                return RedirectToAction("Index");
            }
            return View(documento);
        }

        // GET: documentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: documentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ng.DeletedDocumentos(id);
            return RedirectToAction("Index");
        }

        public ActionResult Filtro(string buscar)
        {
            var filtro = from s in db.documento
                         select s;
            if (!String.IsNullOrEmpty(buscar))
            {
                filtro = filtro.Where(s => s.empleado.Contains(buscar));
            }
            return View(filtro.ToList());
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
