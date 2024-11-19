using Capa_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace registroSocial8.Controllers
{
    public class EstadoController : Controller
    {

        private readonly EstadoBL _estadoBL;

        // El constructor ahora inyecta el servicio ServiciosBL
        public EstadoController(EstadoBL estadoBL)
        {
            _estadoBL = estadoBL; // Aquí se inicializa el servicio con la inyección de dependencias
        }

        // GET: EstadoController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listareEstados()
        {
            // Usamos _serviciosBL ya inyectado, no es necesario crear una nueva instancia
            var estados = _estadoBL.ListarServicios();
            return new JsonResult(estados);
        }
        public JsonResult traerEstadoId(int id)
        {
            // Usamos _serviciosBL ya inyectado, no es necesario crear una nueva instancia
            var estado = _estadoBL.traerEstadoId(id);
            return new JsonResult(estado);
        }

        public JsonResult traerEstadoNombre(string nombre)
        {
            // Usamos _serviciosBL ya inyectado, no es necesario crear una nueva instancia
            var estado = _estadoBL.traerEstadoNombre(nombre);
            return new JsonResult(estado);
        }
    }
}
