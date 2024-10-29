using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;

namespace registroSocial.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult listarPacientes()
        {

            PacienteBL responsableBL = new PacienteBL();

            return Json(responsableBL.listarPaciente(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult filtrarPacientes(string parametro)
        {

            PacienteBL responsableBL = new PacienteBL();

            return Json(responsableBL.filtrarPaciente(parametro), JsonRequestBehavior.AllowGet);

        }

        // GET: RegistroSocial
        public ActionResult DatosPaciente()
        {
            return View();
        }
    }
}