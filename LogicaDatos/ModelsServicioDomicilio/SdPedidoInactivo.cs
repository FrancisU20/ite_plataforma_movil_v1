using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdPedidoInactivo
    {
        public long PcaCodigo { get; set; }
        public string PinTipoOperacion { get; set; }
        public string PinObservacion { get; set; }
        public DateTime PinFecha { get; set; }
        public string PinEstado { get; set; }

        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
    }
}
