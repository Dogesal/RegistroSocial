﻿using System;
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

    }
}
