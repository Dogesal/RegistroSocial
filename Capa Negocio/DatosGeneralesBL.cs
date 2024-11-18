using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class DatosGeneralesBL
    {

        public List<DatosGeneralesCLS> listarRegistroSocial()
        {
            DatosGeneralesDAL registroSocialDAL = new DatosGeneralesDAL();

            return registroSocialDAL.listarRegistroSocial();

        }

        public List<DatosGeneralesPacienteCLS> listarRegistroSocialPaciente()
        {
            DatosGeneralesDAL registroSocialDAL = new DatosGeneralesDAL();

            return registroSocialDAL.listarRegistroSocialPaciente();

        }

        public List<DatosGeneralesPacienteCLS> filtrarRegistroSocial(string parametro)
        {
            DatosGeneralesDAL registroSocialDAL = new DatosGeneralesDAL();

            return registroSocialDAL.filtrarRegistroSocial(parametro);

        }

    }
}
