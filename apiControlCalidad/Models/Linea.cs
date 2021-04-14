using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Linea
    {
        [Key]
        public int idlinea { get; set; }
        public int numero {get; set;}
    }
}
