using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class ArticuloModel
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string barra { get; set; }
        public int valorconversion { get; set; }
        public int stock { get; set; }
        public int ingreso { get; set; }
        public bool coincide { get; set; }
    }
}
