using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ResponsableCLS
    {
        public int IDResponsable { get; set; }
        public int IDPaciente { get; set; }
        public string NombreResponsable { get; set; }
        public int Edad { get; set; }
        public string DNI { get; set; }
        public string Ocupacion { get; set; }
        public string Parentesco { get; set; }
        public string CelularResponsable { get; set; }
        public string GradoInstruccion { get; set; }
    }
}
