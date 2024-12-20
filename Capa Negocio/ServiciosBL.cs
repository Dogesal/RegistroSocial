﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public ServicioCLS traerServicioNombre(string servicio)
        {
            try
            {
                // Buscar el primer estado que coincida con el nombre
                var estado = _context.servicios
                                     .FirstOrDefault(e => e.nombre == servicio);

                if (estado == null)
                {
                    // Si no se encuentra ningún estado, lanzar una excepción con un mensaje más específico
                    throw new Exception($"No se encontró un servicio con el nombre '{servicio}'.");
                }

                return estado;
            }
            catch (Exception e)
            {
                // Capturar cualquier excepción y lanzar un mensaje de error más informativo
                throw new Exception($"Error al buscar el estado: {e.Message}", e);
            }
        }

    }
}
