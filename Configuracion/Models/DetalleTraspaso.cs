using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Configuracion.Models
{
    public class DetalleTraspaso
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int entero { get; set; }
        public int fraccion { get; set; }
        public int mas { get; set; }
        public int menos { get; set; }
        public int cantidad { get; set; }
        public decimal pvf { get; set; }
        public string cadenaFrio { get; set; }
        public int TRD_CANF { get; set; }
        public int od_cantidad_facturado { get; set; }
        public List<TemperaturaModel> temperaturas { get; set; } = new List<TemperaturaModel>();
        public List<R_Barra> barras { get; set; }
    }
}
