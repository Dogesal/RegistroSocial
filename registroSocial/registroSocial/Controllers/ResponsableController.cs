using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace registroSocial.Controllers
{
    public class ResponsableController : Controller
    {
        // GET: Responsable
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarResponsables() {

            ResponsableBL responsableBL = new ResponsableBL();

            return Json(responsableBL.listarResponsable(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DatosResponsable() {


            return View();

        }
        

    }
}