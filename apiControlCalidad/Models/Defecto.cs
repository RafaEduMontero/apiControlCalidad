using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Defecto
    {
        [Key]
        public int iddefecto { get; set; }
        public string descripcion { get; set; }
        public string tipo_defecto { get; set; }
    }
}
