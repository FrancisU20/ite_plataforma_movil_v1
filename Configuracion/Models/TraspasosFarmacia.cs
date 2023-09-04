using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class TraspasosFarmacia
    {
        public int orden { get; set; }
        public string fecha { get; set; }
        public string traspaso { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string bodega_org { get; set; }
        public string guia { get; set; }
        public string observacion { get; set; }
        public string PedidoFacturado { get; set; }
    }
}
