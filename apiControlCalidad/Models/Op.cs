using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Op
    {
        [Key]
        public int idop { get; set; }
        
        public string estado { get; set; }

        public string numero_op { get; set; }

        public string color_codigo { get; set; }
        public string modelo_sku { get; set; }
        public int modelo_objetivo { get; set; }
        public string empleado_dni { get; set; }
        public int linea_numero { get; set; }


        public string fecha_inicio { get; set; }

        public string fecha_fin { get; set; }

        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
    }
}
