using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ServiciosBL
    {
        private readonly ServicioContextDAL _context;

        public ServiciosBL(ServicioContextDAL context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
            }

            _context = context;
        }



        public IEnumerable<ServicioCLS> ListarServicios()
        {
            return _context.servicios.ToList();
        }

        public ServicioCLS CrearServicio(ServicioCLS servicio)
        {
            _context.servicios.Add(servicio);
            _context.SaveChanges();

            return servicio;
        }

    }
}
