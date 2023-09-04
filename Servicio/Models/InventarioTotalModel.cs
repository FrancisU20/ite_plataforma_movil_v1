using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class InventarioTotalModel
    {
        public string Sucursal { get; set; }
        public string Oficina { get; set; }
        public string IdBodega { get; set; }
        public long CodigoInventario { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string LabelTotal { get; set; }
        public int NumeroConteo { get; set; }
        public bool CabeceraVisible { get; set; }
        public bool CabeceraOCVisible { get; set; }
        public int Margen { get; set; }
    }
}
