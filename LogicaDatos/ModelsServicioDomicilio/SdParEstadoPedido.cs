using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdParEstadoPedido
    {
        public SdParEstadoPedido()
        {
            SdPedidosCab = new HashSet<SdPedidosCab>();
        }

        public int EspCodigo { get; set; }
        public string EspNombre { get; set; }
        public string EspTiempoMax { get; set; }
        public string EspColorPrincipal { get; set; }
        public string EspColorFueraTiempo { get; set; }
        public string EspEstado { get; set; }

        public virtual ICollection<SdPedidosCab> SdPedidosCab { get; set; }
    }
}
