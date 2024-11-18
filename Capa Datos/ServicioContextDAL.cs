using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Microsoft.EntityFrameworkCore;

namespace Capa_Datos
{
    public class ServicioContextDAL:DbContext
    {
        public ServicioContextDAL(DbContextOptions<ServicioContextDAL> options) : base(options) { }

        public DbSet<ServicioCLS> servicios { get; set; }

        
    }
}
