using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesMovPremiosActual
    {
        public string MpnCompania { get; set; }
        public string MpnSucural { get; set; }
        public string MpnOficina { get; set; }
        public string MpnIdCliente { get; set; }
        public string MpnIdPromociones { get; set; }
        public string MpnCodigoArticulo { get; set; }
        public string MpnTipoArticulo { get; set; }
        public int? MpnNumeroMov { get; set; }
        public string MpnTipoMov { get; set; }
        public DateTime? MpnFechaMov { get; set; }
        public decimal? MpnCantidad { get; set; }
        public decimal? MpnCantidadTotal { get; set; }
        public string MpnSerieFactura { get; set; }
        public string MpnEstado { get; set; }
        public string MpnObservacion { get; set; }
        public string MpnEnvioPos { get; set; }
        public string MpnEstadoCanje { get; set; }
        public string MpnTipo { get; set; }
        public int? PcaCodigo { get; set; }
    }
}
