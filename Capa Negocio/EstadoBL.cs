using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public  class EstadoBL
    {
        private readonly EstadoContextDAL _context;

        public EstadoBL(EstadoContextDAL context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
            }

            _context = context;
        }



        public IEnumerable<EstadoCLS> ListarServicios()
        {
            return _context.estado.ToList();
        }

        public EstadoCLS traerEstadoId(int ID_estado)
        {
            try {

                return _context.estado.Find(ID_estado);

            }
            catch (Exception e)
            {
                throw new Exception($"No se encontro: {e.Message}");
            }

           
        }

        public EstadoCLS traerEstadoNombre(string nombre)
        {
            try
            {
                // Buscar el primer estado que coincida con el nombre
                var estado = _context.estado
                                     .FirstOrDefault(e => e.nombre == nombre);

                if (estado == null)
                {
                    // Si no se encuentra ningún estado, lanzar una excepción con un mensaje más específico
                    throw new Exception($"No se encontró un estado con el nombre '{nombre}'.");
                }

                return estado;
            }
            catch (Exception e)
            {
                // Capturar cualquier excepción y lanzar un mensaje de error más informativo
                throw new Exception($"Error al buscar el estado: {e.Message}", e);
            }


        }

        public EstadoCLS CrearServicio(EstadoCLS estado)
        {
            _context.estado.Add(estado);
            _context.SaveChanges();

            return estado;
        }
    }
}
