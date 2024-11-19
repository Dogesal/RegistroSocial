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
        private readonly RegistroSocialDAL _registroSocialDAL;
        public RegistroSocialBL(RegistroSocialDAL registroSocialDAL) {


            _registroSocialDAL= registroSocialDAL;


        }

        public RegistroSocialCLS registroSocial(int id)
        {

            return _registroSocialDAL.RegistroSocial(id);



        }

        public string guardadRegistroSocial(RegistroSocialCLS registro)
        {

            return _registroSocialDAL.AgregarRegistroSocial(registro);

        }

        public int EliminarRegistroSocial(int id)
        {


            return _registroSocialDAL.EliminarRegistroSocial(id);

        }

        public string editarRegistroSocial(int id, RegistroSocialCLS registroSocial)
        {
        
            return _registroSocialDAL.EditarRegistroSocial(id,registroSocial);

        }
    }
}
