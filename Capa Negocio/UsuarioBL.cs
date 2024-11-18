using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class UsuarioBL
    {

        public int verificarPassword(string usuario, string password)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();

            return usuarioDAL.verificarPassword(usuario,password);

        }

    }
}
