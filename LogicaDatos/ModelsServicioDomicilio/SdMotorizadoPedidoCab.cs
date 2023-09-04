using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdMotorizadoPedidoCab
    {
        public long PcaCodigo { get; set; }
        public int MotCodigo { get; set; }
        public DateTime MpFecha { get; set; }
        public string MpEstado { get; set; }

        public virtual SdMotorizado MotCodigoNavigation { get; set; }
        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
    }
}
