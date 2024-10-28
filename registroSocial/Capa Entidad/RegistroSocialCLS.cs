
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class RegistroSocialCLS
    {
        public int IDRegistroSocial { get; set; }
        public int IDPaciente { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Servicio { get; set; }
        public string Cama { get; set; }
        public string ModalidadIngreso { get; set; }
        public string TipoFamilia { get; set; }
        public string ObservacionesFamilia { get; set; }
        public string AccionesRealizadas { get; set; }
        public string DiagnosticoSocial { get; set; }
    }
}
