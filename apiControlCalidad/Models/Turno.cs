using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Turno
    {
        [Key]
        public int idturno { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
    }
}
