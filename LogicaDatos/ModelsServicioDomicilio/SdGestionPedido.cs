using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdGestionPedido
    {
        public long PcaCodigo { get; set; }
        public string GesPedidoServicioDomicilio { get; set; }
        public string GesPedidoFarmacia { get; set; }
        public string GesIpFarmacia { get; set; }
        public string GesMotorizadoServicioDomicilio { get; set; }
        public string GesMotorizadoFarmacia { get; set; }
        public string GesScriptServicioDomicilio { get; set; }
        public string GesScriptMotorizados { get; set; }
        public string GesEstado { get; set; }
        public int GesCodigo { get; set; }

        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
    }
}
