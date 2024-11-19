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

        private readonly RegistroSocialBL _registroSocialBL;

        public RegistroSocialController(RegistroSocialBL registroSocialBL)
        {
            _registroSocialBL = registroSocialBL;
        }



        // GET: RegistroSocial
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult traerRegistroSocial(int id)
        {
            
            return new JsonResult(_registroSocialBL.registroSocial(id));
        }

        [HttpPost]
        public JsonResult editarRegistroSocial(int id, [FromBody] RegistroSocialCLS registroSocialR)
        {
            
            return new JsonResult(_registroSocialBL.editarRegistroSocial(id, registroSocialR));
        }

        [HttpPost]
        public JsonResult guardarRegistroSocial([FromBody] RegistroSocialCLS registroSocialR)
        {
            
            return new JsonResult(_registroSocialBL.guardadRegistroSocial(registroSocialR));
        }

        [HttpPost]
        public JsonResult eliminarRegistroSocial(int id)
        {
           
            return new JsonResult(_registroSocialBL.EliminarRegistroSocial(id));
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
