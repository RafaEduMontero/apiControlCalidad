using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiControlCalidad.Models
{
    public class Modelo
    {
        [Key]
        public int idmodelo { get; set; }
        public string sku { get; set; }
        public string denominacion { get; set; }
        public int objetivo { get; set; }
    }
}
