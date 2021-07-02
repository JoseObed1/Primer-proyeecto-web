using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Datos;
using System.Web.Security;

namespace Capa_Presentacion2.Controllers
{
    public class LoginController : Controller
    {
        private BDPEntities db = new BDPEntities();
        // GET: Login
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        public ActionResult Signup(cuentas cuentas)
        {
            if(db.cuentas.Any(x=>x.correo == cuentas.correo))
            {
                ViewBag.Notification = "Esta cuenta ya existe";
            }
            return View();
        }

        public ActionResult LoginOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("create", "cuentas");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "id_cuenta,nombre,correo,pass")] cuentas cuentas)
        {
            var cheak = db.cuentas.Where(x=>x.correo.Equals(cuentas.correo)&&x.pass.Equals(cuentas.pass)).FirstOrDefault();
            if (cheak != null)
            {
                Session["UserName"] = cheak.nombre.ToString();
                FormsAuthentication.SetAuthCookie(cuentas.correo, true);
                return RedirectToAction("Index", "documentoes");
            }
            else
            {
                ViewBag.Notification = "Correo o contraseña no son correctos";
            }
            return View();
        }
    }
}