using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesFacturas
    {
        public long PfaIdPromociones { get; set; }
        public string PfaSerieFactura { get; set; }
        public DateTime PfaFechaInicio { get; set; }
        public DateTime PfaFechaFin { get; set; }
        public string PfaTipoIdCliente { get; set; }
        public string PfaNumeroIdCliente { get; set; }
        public string PfaCompania { get; set; }
        public string PfaTipoDocumento { get; set; }
        public string PfaEstablecimientoSri { get; set; }
        public short? PfaPuntoFacturacion { get; set; }
        public long? PfaNumFactura { get; set; }
        public decimal? PfaTotalFactura { get; set; }
        public DateTime? PfaFechaFactura { get; set; }
        public string PfaUsuarioFactura { get; set; }
        public decimal? PfaValDescuento { get; set; }
        public decimal? PfaValorExtra { get; set; }
        public string PfaReimprimir { get; set; }
        public string PfaEnvioPos { get; set; }
    }
}
