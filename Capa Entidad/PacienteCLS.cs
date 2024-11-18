using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class PacienteCLS
    {
        public int IDPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string DNI { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string GradoInstruccion { get; set; }
        public string Direccion { get; set; }
        public string CelularPaciente { get; set; }
        public string Ocupacion { get; set; }
        public int NumHijos { get; set; }
        public int NumHermanos { get; set; }
        public string Seguro { get; set; }
        public string DxMedico { get; set; }
    }
}
