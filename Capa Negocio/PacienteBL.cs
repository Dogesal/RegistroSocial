using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;
namespace Capa_Negocio
{
    public class PacienteBL
    {
        public List<PacienteCLS> listarPaciente()
        {
            PacienteDAL PacienteDAL = new PacienteDAL();

            return PacienteDAL.listarPaciente();

        }

        public List<PacienteCLS> filtrarPaciente(string parametro)
        {
            PacienteDAL PacienteDAL = new PacienteDAL();

            return PacienteDAL.filtrarPaciente(parametro);

        }
    }
}
