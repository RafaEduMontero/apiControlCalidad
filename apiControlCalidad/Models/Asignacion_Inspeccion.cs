using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Asignacion_Inspeccion
    {
        [Key]
        public int idasignacion { get; set; }
        public string op_numero_op { get; set; }
        public string empleado_dni { get; set; }

        public string estado { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
    }
}
