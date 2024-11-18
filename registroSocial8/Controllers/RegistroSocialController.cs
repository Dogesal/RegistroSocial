using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace registroSocial.Controllers
{
    public class RegistroSocialController : Controller
    {
        // GET: RegistroSocial
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult traerRegistroSocial(int id)
        {
            RegistroSocialBL registroBL = new RegistroSocialBL();
            return new JsonResult(registroBL.registroSocial(id));
        }

        [HttpPost]
        public JsonResult editarRegistroSocial(int id, [FromBody] RegistroSocialCLS registroSocialR)
        {
            RegistroSocialBL registroBL = new RegistroSocialBL();
            return new JsonResult(registroBL.editarRegistroSocial(id, registroSocialR));
        }

        [HttpPost]
        public JsonResult guardarRegistroSocial([FromBody] RegistroSocialCLS registroSocialR)
        {
            RegistroSocialBL registroBL = new RegistroSocialBL();
            return new JsonResult(registroBL.guardadRegistroSocial(registroSocialR));
        }

        [HttpPost]
        public JsonResult eliminarRegistroSocial(int id)
        {
            RegistroSocialBL registroBL = new RegistroSocialBL();
            return new JsonResult(registroBL.EliminarRegistroSocial(id));
        }

        public IActionResult RegistroSocial()
        {
            return View();
        }

        public IActionResult RegistroSocialVista()
        {
            return View();
        }

        public IActionResult RegistroSocialEdit()
        {
            return View();
        }
    }
}
