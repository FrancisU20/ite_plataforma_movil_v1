using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFpconvenioParametros
    {
        public string ConIdConvenio { get; set; }
        public string ConFacturaA { get; set; }
        public string ConRucInstitucion { get; set; }
        public string ConListaPrecios { get; set; }
        public string ConNoCopias { get; set; }
        public string ConCubreIva { get; set; }
        public string ConLeyenda { get; set; }
        public string ConNombreConv { get; set; }
        public string ConDescuento { get; set; }
        public string ConCodBarra { get; set; }
        public string ConDescuentoBarra { get; set; }
        public string ConValDescuento { get; set; }
        public string ConPorCon { get; set; }
        public string ConEstado { get; set; }
        public string ConDeducible { get; set; }
        public string ConCopago { get; set; }
        public string ConAutorizacion { get; set; }
        public string ConPromocionesConvenio { get; set; }
        public string ConClienteFactura { get; set; }
        public long PcaCodigo { get; set; }
        public int? MesesPlazo { get; set; }
    }
}
