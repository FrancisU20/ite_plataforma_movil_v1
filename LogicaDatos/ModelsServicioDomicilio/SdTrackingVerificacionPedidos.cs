using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTrackingVerificacionPedidos
    {
        public int TrkCodigo { get; set; }
        public long PcaCodigo { get; set; }
        public string PcsSerieFactura { get; set; }
        public DateTime? TkpFechaRegistro { get; set; }
        public string TkpObservacion { get; set; }
        public string TrpNumeroTransferencia { get; set; }

        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
        public virtual SdTrackingMotorizadoPedidos TrkCodigoNavigation { get; set; }
    }
}
