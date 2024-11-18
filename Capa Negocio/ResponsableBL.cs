using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ResponsableBL
    {
        public List<ResponsableCLS> listarResponsable()
        {
            ResponsableDAL registroSocialDAL = new ResponsableDAL();

            return registroSocialDAL.listarResponsable();

        }

        public List<ResponsableCLS> filtrarResponsable(string parametro)
        {
            ResponsableDAL registroSocialDAL = new ResponsableDAL();

            return registroSocialDAL.filtrarResponsable(parametro);

        }
    }
}
