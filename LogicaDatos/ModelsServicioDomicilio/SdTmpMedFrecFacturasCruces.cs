using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpMedFrecFacturasCruces
    {
        public string CruCompania { get; set; }
        public string CruSucursal { get; set; }
        public string CruOficina { get; set; }
        public string CruTipoDocumento { get; set; }
        public int CruNumeroFactura { get; set; }
        public string CruSerieFactura { get; set; }
        public string CruTipoIdmedico { get; set; }
        public string CruCodigoMedico { get; set; }
        public int CruNumeroAutMf { get; set; }
        public string CruEsMf { get; set; }
        public string CruProcesoMf { get; set; }
        public string CruIdBodega { get; set; }
        public DateTime CruFechaFactura { get; set; }
        public string CruTipoIdcliente { get; set; }
        public string CruNumeroIdcliente { get; set; }
        public string CruCodigoProducto { get; set; }
        public float CruCantidad { get; set; }
        public string CruEstablecimientoSri { get; set; }
        public string CruTipoMf { get; set; }
        public string CruEstado { get; set; }
        public string CruDevolucion { get; set; }
        public DateTime CruFechaCanje { get; set; }
        public string CruNumeroFacturaCanje { get; set; }
        public int CruIdArticulosPromocion { get; set; }
        public int CruIdPremio { get; set; }
        public float CruSaldo { get; set; }
        public string CruAuxiliar { get; set; }
    }
}
