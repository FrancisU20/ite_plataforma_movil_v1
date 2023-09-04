using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class BuscarArticuloInventarioTotalModel
    {
        //string codigo, string codigoBarras, string descripcion, int conteo, int inventario

        public string Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public int Conteo { get; set; }
        public int Inventario { get; set; }
        public string Usuario { get; set; }
    }
}
