using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpDatosRetencion
    {
        public string SerieFactura { get; set; }
        public string PcrCodigo { get; set; }
        public string PcrImpuesto { get; set; }
        public string DrTipo { get; set; }
        public string Sucursal { get; set; }
        public string Oficina { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string NumeroIdcliente { get; set; }
        public string DrTipoComprobante { get; set; }
        public string DrNumeroRetencion { get; set; }
        public string DrComprobanteContable { get; set; }
        public decimal? DrBaseImponible { get; set; }
        public decimal? DrPorcentajeRetencion { get; set; }
        public decimal? DrValorRetencion { get; set; }
        public string DrAnioFiscal { get; set; }
        public string DrNumeroAutorizacion { get; set; }
        public DateTime? DrValidezRetencion { get; set; }
        public string DrEstado { get; set; }
        public string DrUsuario { get; set; }
        public string EnvioPos { get; set; }
        public long PcaCodigo { get; set; }
    }
}
