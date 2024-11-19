using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Microsoft.EntityFrameworkCore;


namespace Capa_Datos
{
    public class EstadoContextDAL:DbContext
    {
        public EstadoContextDAL(DbContextOptions<EstadoContextDAL> options) : base(options) { }

        public DbSet<EstadoCLS> estado { get; set; }

    }
}
