using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdDatosEcommerce
    {
        public string DeCanal { get; set; }
        public string DeReferencia { get; set; }
        public string DeEstado { get; set; }
        public DateTime? DeFechaEcommerce { get; set; }
        public string DeObservacion { get; set; }
        public long PcaCodigo { get; set; }
        public string EnvioPos { get; set; }
    }
}
