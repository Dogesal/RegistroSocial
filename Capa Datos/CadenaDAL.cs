using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Capa_Datos
{
    public class CadenaDAL
    {
        public string cadenaConexion { get; set; }

        public CadenaDAL(){

            cadenaConexion = "server=HDHVCA;database=registroSocial;Integrated Security=true;TrustServerCertificate=True";
        }


    }
}
