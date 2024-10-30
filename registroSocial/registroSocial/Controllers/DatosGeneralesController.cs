using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;

namespace registroSocial.Controllers
{
    public class DatosGeneralesController : Controller
    {
        // GET: RegistroSocial
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroSocial
        public ActionResult Registro()
        {
            return View();
        }

        // GET: RegistroSocial
        public ActionResult Busqueda()
        {
            return View();
        }

        

        public JsonResult registroSocial()
        {
            DatosGeneralesBL obj = new DatosGeneralesBL();

            return Json(obj.listarRegistroSocial(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult filtrarregistroSocial(string parametro)
        {
            DatosGeneralesBL obj = new DatosGeneralesBL();

            return Json(obj.filtrarRegistroSocial(parametro), JsonRequestBehavior.AllowGet);
        }


    }


}