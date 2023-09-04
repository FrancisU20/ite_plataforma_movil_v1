using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdParEnlacePrioridad
    {
        public int EnlpId { get; set; }
        public string EnlpOficina { get; set; }
        public string EnlpServidor { get; set; }
        public string EnlpIp { get; set; }
        public int? EnlpPrioridad { get; set; }
        public string EnlpEstado { get; set; }
        public string EnlpObservacion { get; set; }
    }
}
