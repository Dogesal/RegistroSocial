using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class RegistroSocialBL
    {
        public RegistroSocialCLS registroSocial(int id)
        {

            RegistroSocialDAL obj = new RegistroSocialDAL();

            return obj.RegistroSocial(id);



        }

        public string guardadRegistroSocial(RegistroSocialCLS registro)
        {
            RegistroSocialDAL obj = new RegistroSocialDAL();

            return obj.AgregarRegistroSocial(registro);

        }

        public int EliminarRegistroSocial(int id)
        {
            RegistroSocialDAL obj = new RegistroSocialDAL();

            return obj.EliminarRegistroSocial(id);

        }

        public string editarRegistroSocial(int id, RegistroSocialCLS registroSocial)
        {
            RegistroSocialDAL obj = new RegistroSocialDAL();

            return obj.EditarRegistroSocial(id,registroSocial);

        }
    }
}
