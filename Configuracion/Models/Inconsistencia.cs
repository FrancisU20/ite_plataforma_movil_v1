using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class Inconsistencia
    {
        public string mensajeInconsistencia { get; set; }
        public string mensajeTraspaso { get; set; }
        public string traspaso { get; set; }
        public string fecha { get; set; }
        public string existeInconsistencia { get; set; }
        public List<DetalleInconsistencia> detalleInco { get; set; }
    }
}
