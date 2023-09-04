using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesMovPremios
    {
        public string PmpCompania { get; set; }
        public string PmpSucursal { get; set; }
        public string PmpOficina { get; set; }
        public string PmpIdCliente { get; set; }
        public string PmpIdPromociones { get; set; }
        public string PmpCodigoArticulo { get; set; }
        public string PmpTipoArticulo { get; set; }
        public long PmpNumeroMov { get; set; }
        public string PmpTipoMov { get; set; }
        public DateTime? PmpFechaMov { get; set; }
        public decimal? PmpCantidad { get; set; }
        public decimal? PmpCantidadTotal { get; set; }
        public string PmpSerieFactura { get; set; }
        public string PmpEstado { get; set; }
        public string PmpObservacion { get; set; }
        public string PmpEnvioPos { get; set; }
        public string PmpEstadoCanje { get; set; }
        public string PmpTipo { get; set; }
    }
}
