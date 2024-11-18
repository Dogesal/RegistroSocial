using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Negocio;
using Capa_Entidad;
using Microsoft.AspNetCore.Mvc;

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

            return new JsonResult(responsableBL.listarResponsable());
        }

        public JsonResult filtrarResponsables(string parametro)
        {

            ResponsableBL responsableBL = new ResponsableBL();

            return new JsonResult(responsableBL.filtrarResponsable(parametro));
        }

        public ActionResult DatosResponsable() {


            return View();

        }
        

    }
}