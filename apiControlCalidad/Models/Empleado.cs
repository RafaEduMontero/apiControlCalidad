using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Empleado
    {
        [Key]
        public int idempleado { get; set; }
        public string nombre { get; set; }
        public  string apellido { get; set; }
        public string dni { get; set; }
        public  string sexo { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
    }
}
