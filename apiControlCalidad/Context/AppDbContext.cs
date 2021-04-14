using apiControlCalidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Color> color { get; set; }
        public DbSet<Linea> linea { get; set; }

        public DbSet<Modelo> modelo { get; set; }

        public DbSet<Defecto> defecto { get; set; }

        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Turno> turno { get; set; }
        public DbSet<Op> op { get; set; }
        public DbSet<Asignacion_Inspeccion> asignacion_inspeccion { get; set; }
        public DbSet<Inspeccion> inspeccion { get; set; }   
    }
}
