using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Inspeccion
    {
        [Key]
        public int idinspeccion { get; set; }
        public string tipo_defecto { get; set; }
        public int cantidad { get; set; }
        public string hora { get; set; }
        public string pie { get; set; }
        public string op_numero_op {get;set;}
        public string fecha { get; set; }
    }
}
