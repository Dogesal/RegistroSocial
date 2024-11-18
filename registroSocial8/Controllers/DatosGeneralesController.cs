using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capa_Negocio;
using Capa_Entidad;
using Microsoft.AspNetCore.Mvc;

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

            return new JsonResult(obj.listarRegistroSocial());
        }


        public JsonResult registroSocialPaciente()
        {
            DatosGeneralesBL obj = new DatosGeneralesBL();

            return new JsonResult(obj.listarRegistroSocialPaciente());
        }

        public JsonResult filtrarregistroSocial(string parametro)
        {
            DatosGeneralesBL obj = new DatosGeneralesBL();

            return new JsonResult(obj.filtrarRegistroSocial(parametro));
        }


    }


}