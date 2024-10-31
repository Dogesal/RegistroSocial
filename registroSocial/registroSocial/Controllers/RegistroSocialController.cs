using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace registroSocial.Controllers
{
    public class RegistroSocialController : Controller
    {
        // GET: RegistroSocial
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult traerRegistroSocial(int id)
        {

            RegistroSocialBL registroBL = new RegistroSocialBL();

            return Json(registroBL.registroSocial(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegistroSocial()
        {


            return View();

        }
    }
}