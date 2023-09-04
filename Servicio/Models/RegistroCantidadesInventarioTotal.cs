using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class RegistroCantidadesInventarioTotal
    {
        public string Usuario { get; set; }
        public string IpCliente { get; set; }
        public int Entero { get; set; }
        public int Fraccion { get; set; }
        public string CodigoArticulo { get; set; }
        public int ValorPos { get; set; }
        public int Conteo { get; set; }
        public int Inventario { get; set; }
    }
}
