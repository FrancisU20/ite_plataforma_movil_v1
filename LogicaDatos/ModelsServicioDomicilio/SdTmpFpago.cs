using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFpago
    {
        public string FpAbreviatura { get; set; }
        public string FpNombreEfp { get; set; }
        public string FpValor { get; set; }
        public string FpNoVaucher { get; set; }
        public string FpValidez { get; set; }
        public string FpNoTarjeta { get; set; }
        public string FpAutorizacion { get; set; }
        public string FpTelefono { get; set; }
        public string FpLote { get; set; }
        public string FpNoRetencion { get; set; }
        public string FpTipoRetencion { get; set; }
        public string FpNoCheque { get; set; }
        public string FpCodigoBanco { get; set; }
        public string FpCuenta { get; set; }
        public string FpAutMatriz { get; set; }
        public string FpDeducible { get; set; }
        public string FpCopago { get; set; }
        public string FpRecargo { get; set; }
        public string FpDescAdicional { get; set; }
        public string FpNombreCorto { get; set; }
        public int? FpIdFila { get; set; }
        public string FpTarjeta { get; set; }
        public string FpIdEmisor { get; set; }
        public string FpNoEmisor { get; set; }
        public string FpPlazoVencimiento { get; set; }
        public string FpTipoCredito { get; set; }
        public long PcaCodigo { get; set; }
    }
}
