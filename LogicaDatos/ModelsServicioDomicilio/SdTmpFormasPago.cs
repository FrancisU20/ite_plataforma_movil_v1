using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFormasPago
    {
        public string PfTipoPago { get; set; }
        public string PfValorPagado { get; set; }
        public decimal? PfVuelto { get; set; }
        public int? PfIdFila { get; set; }
        public decimal? PfDescuento { get; set; }
        public long? PcaCodigo { get; set; }
    }
}
