using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class RegistroSocialBL
    {

        public List<RegistroSocialCLS> listarRegistroSocial()
        {
            RegistroSocialDAL registroSocialDAL = new RegistroSocialDAL();

            return registroSocialDAL.listarRegistroSocial();

        }

        public List<RegistroSocialCLS> filtrarRegistroSocial(string parametro)
        {
            RegistroSocialDAL registroSocialDAL = new RegistroSocialDAL();

            return registroSocialDAL.filtrarRegistroSocial(parametro);

        }

    }
}
