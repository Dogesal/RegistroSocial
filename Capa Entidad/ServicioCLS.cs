using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ServicioCLS
    {
        [Key]
        public int ID_servicio { get; set; }
        public string nombre { get; set; }
    }
}
