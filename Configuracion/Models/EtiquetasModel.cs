using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
   public class EtiquetasModel
    {
        public string codigo_articulo { get; set; }
        public string codigo_barras { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public string usuario_registro { get; set; }
    }
}
