using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdDatosMovil
    {
        public string DmNumeroIdcliente { get; set; }
        public string DmNumeroMovil { get; set; }
        public string DmCoordenadas { get; set; }
        public int? DmContadorMovil { get; set; }
        public string DmObservacion { get; set; }
        public long? PcaCodigo { get; set; }
    }
}
