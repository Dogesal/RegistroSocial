using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class RegistroSocialCLS
    {

        public PacienteCLS paciente { get; set; }
        public DatosGeneralesCLS datos { get; set; }
        public List<ResponsableCLS> responsables { get; set; }

        public ServicioCLS servicio { get; set; }

        public EstadoCLS estado { get; set; }

    }
}
