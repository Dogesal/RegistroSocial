using Microsoft.AspNetCore.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace registroSocial.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public IActionResult Index()
        {


            return View();
        }

        // Acción POST para verificar la contraseña
        [HttpPost]
        public JsonResult verificarPassword([FromBody] UsuarioCLS login)
        {
            UsuarioBL usuarioBL = new UsuarioBL();
            int resultado = usuarioBL.verificarPassword(login.usuario, login.password);

            if (resultado == 1) // Si la autenticación es exitosa
            {
                HttpContext.Session.SetString("UsuarioAutenticado", "true");
                HttpContext.Session.SetString("NombreUsuario", "Juan Pérez");
            }

            return new JsonResult(resultado);
        }

        // Acción para cerrar sesión
        public IActionResult Logout()
        {
            // Limpiar la sesión
            HttpContext.Session.Remove("UsuarioAutenticado");
            HttpContext.Session.Remove("NombreUsuario");


            return RedirectToAction("Index", "Usuario");
        }
    }
}
