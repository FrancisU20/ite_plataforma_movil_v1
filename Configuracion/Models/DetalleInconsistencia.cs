using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class DetalleInconsistencia
    {
        public string motivo { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int entero { get; set; }
        public int fraccion { get; set; }
    }
}
