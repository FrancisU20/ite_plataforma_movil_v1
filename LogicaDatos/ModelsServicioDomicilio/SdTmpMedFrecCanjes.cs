using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpMedFrecCanjes
    {
        public string MfcCodigo { get; set; }
        public int? MfcCantidad { get; set; }
        public string MfcEstado { get; set; }
        public int? MfcSaldo { get; set; }
        public string MfcActualizar { get; set; }
        public string MfcDevolucion { get; set; }
        public DateTime? MfcFechaCanje { get; set; }
        public string MfcNumeroFacturaCanje { get; set; }
        public int? MfcIdArticulosPromocion { get; set; }
        public int? MfcIdPremio { get; set; }
        public string MfcAuxiliar { get; set; }
        public string MfcFormaPago { get; set; }
        public string MfcCodigoOriginal { get; set; }
    }
}
