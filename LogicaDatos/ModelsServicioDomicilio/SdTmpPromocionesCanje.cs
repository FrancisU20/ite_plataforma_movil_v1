using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesCanje
    {
        public string PrcIdPromocion { get; set; }
        public string PrcIdCliente { get; set; }
        public string PrcCodigoArticulo { get; set; }
        public string PrcSerieFactura { get; set; }
        public string PrcEstado { get; set; }
        public int PcaCodigo { get; set; }
    }
}
