using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class Traspaso
    {
        public string traspaso { get; set; }
        public string usuarioFarmacia { get; set; }
        public string bodega { get; set; }
        public int caja { get; set; }
        public int funda { get; set; }
        public int paca { get; set; }
        public string fechaTraspaso { get; set; }
        public string cadenaFrio { get; set; }
        public double temperaturaCaja { get; set; }
        public List<TemperaturaPostVerificacion> temperaturaPostVerificacion { get; set; }
        public List<DetalleTraspaso> articulos { get; set; }
    }
}
