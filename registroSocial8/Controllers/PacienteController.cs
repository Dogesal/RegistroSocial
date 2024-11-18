using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;

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

            return new JsonResult(responsableBL.listarPaciente());
        }

        public JsonResult filtrarPacientes(string parametro)
        {

            PacienteBL responsableBL = new PacienteBL();

            return new JsonResult(responsableBL.filtrarPaciente(parametro));

        }

        // GET: RegistroSocial
        public ActionResult DatosPaciente()
        {
            return View();
        }
    }
}