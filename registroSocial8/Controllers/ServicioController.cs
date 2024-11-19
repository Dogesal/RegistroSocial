using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace registroSocial8.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ServiciosBL _serviciosBL;

        // El constructor ahora inyecta el servicio ServiciosBL
        public ServicioController(ServiciosBL serviciosBL)
        {
            _serviciosBL = serviciosBL; // Aquí se inicializa el servicio con la inyección de dependencias
        }

        // GET: ServicioController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarServicios()
        {
            // Usamos _serviciosBL ya inyectado, no es necesario crear una nueva instancia
            var servicios = _serviciosBL.ListarServicios();
            return new JsonResult(servicios);
        }

        public JsonResult traerServicioNombre(string nombre)
        {
            // Usamos _serviciosBL ya inyectado, no es necesario crear una nueva instancia
            var estado = _serviciosBL.traerServicioNombre(nombre);
            return new JsonResult(estado);
        }
    }
}
