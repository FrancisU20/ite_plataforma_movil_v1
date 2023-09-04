using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class StockArticuloInventario
    {
        public string Existencias { get; set; }
        public string Entero { get; set; }
        public string Fraccion { get; set; }
        public string ValorPOS { get; set; }
        public string Barra { get; set; }
        public string Codigo { get; set; }
        public string Stock { get; set; }
        public string Unidades { get; set; }
        public string Descripcion { get; set; }
        public string Laboratorio { get; set; }
        public string EsContado { get; set; }
        public List<HistorialConteo> Historiales { get; set; }
    }

    public class HistorialConteo
    {
        public string Usuario { get; set; }
        public string Cantidad { get; set; }
    }
}
