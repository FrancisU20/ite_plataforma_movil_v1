using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class ResumenPlanArticulos
    {
        public int id_plan { get; set; }
        public string codigoArticulo { get; set; }
        public string descripcionArticulo { get; set; }
        public int entero { get; set; }
        public int fraccion { get; set; }
        public int cantidad { get; set; }
        public decimal pvf { get; set; }
        public int valorPos { get; set; }
        public decimal porcentajeDescuento { get; set; }
        public decimal valorDiferencia { get; set; }
    }
}
