using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdPedidosDet
    {
        public int PdeCodigo { get; set; }
        public long PcaCodigo { get; set; }
        public string PdeArticulo { get; set; }
        public string PdeNombreArticulo { get; set; }
        public int PdeCantidadDetalle { get; set; }
        public int PdeCantidadFraccion { get; set; }
        public double PdePrecio { get; set; }
        public string PdeEstado { get; set; }
        public string PdeTieneTransferencia { get; set; }
        public int PdeValorIva { get; set; }
        public string PdeEsMf { get; set; }
        public string PdeTieneDescuento { get; set; }
        public double? PdeValDescuento { get; set; }
        public string PdeEsPromocion { get; set; }
        public double? PdeDescuentoPromocion { get; set; }
        public int PdeCantidadTotal { get; set; }
        public double? PdeDescuentoCabecera { get; set; }
        public string PdeEsDelivery { get; set; }
        public double? PdeValorDescuento { get; set; }

        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
    }
}
