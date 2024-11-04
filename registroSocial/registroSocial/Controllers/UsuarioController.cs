using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace registroSocial.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult verificarPassword(string usuario, string password)
        {

            UsuarioBL usuarioBL = new UsuarioBL();
            int resultado = usuarioBL.verificarPassword(usuario, password);

            if (resultado == 1) // Si la autenticación es exitosa
            {
                // Establece una sesión indicando que el usuario está autenticado
                Session["UsuarioAutenticado"] = true;
                Session["nombre"] = usuario;
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["UsuarioAutenticado"] = null; // Limpia la sesión al cerrar sesión
            return RedirectToAction("Index", "Usuario");
        }
    }
}