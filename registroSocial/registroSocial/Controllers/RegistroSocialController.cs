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

        public JsonResult editarRegistroSocial(int id, RegistroSocialCLS registroSocialR)
        {
            RegistroSocialBL registroBL = new RegistroSocialBL();



            return Json(registroBL.editarRegistroSocial(id, registroSocialR), JsonRequestBehavior.AllowGet);


        }

        public JsonResult guardarRegistroSocial(RegistroSocialCLS registroSocialR)
        {
            RegistroSocialBL registroBL = new RegistroSocialBL();



            return Json(registroBL.guardadRegistroSocial(registroSocialR), JsonRequestBehavior.AllowGet);


        }

        public int eliminarRegistroSocial(int id)
        {

            RegistroSocialBL registroBL = new RegistroSocialBL();

            return registroBL.EliminarRegistroSocial(id);
        }

        public ActionResult RegistroSocial()
        {
            
            return View();

        }

        public ActionResult RegistroSocialVista() {

            return View();
        }

        public ActionResult RegistroSocialEdit()
        {

            return View();
        }
    }
}