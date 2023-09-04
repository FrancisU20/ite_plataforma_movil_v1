using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class BusquedaArticuloTraspasos
    {
        public string traspaso { get; set; }
        public string fecha { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public int  enteros { get; set; }
        public int fraccion { get; set; }
        public string codigo { get; set; }
        public string barra { get; set; }
        public string detalle_articulo { get; set; }
    }
}
