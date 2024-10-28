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

            cadenaConexion = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        }
    }
}
