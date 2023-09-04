using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFpgenerales
    {
        public long PcaCodigo { get; set; }
        public decimal? GenValorExtra { get; set; }
        public string GenSerieNotaCredito { get; set; }
        public string GenAplicaPromocion { get; set; }
        public string GenNoAplicaCupon { get; set; }
        public string GenAceptaMf { get; set; }
        public string GenCodMedicoMf { get; set; }
        public string GenNombreMedicoMf { get; set; }
        public string GenAutorizacion { get; set; }
        public string GenCedulaConvenio { get; set; }
        public string GenTipoConvenio { get; set; }
        public string GenAutorizacionConv { get; set; }
        public decimal? GenRecargo { get; set; }
        public string GenPacienteConv { get; set; }
        public string GenAutorizacionDescuento { get; set; }
        public decimal? GenValorCopagoReceta { get; set; }
        public string GenEsProforma { get; set; }
        public string GenPromocionProforma { get; set; }
        public decimal? GenClsSubtotalIva { get; set; }
        public decimal? GenClsSubtotalNIva { get; set; }
        public string GenEsFacturaCanjeMf { get; set; }
        public int? GenNroReimpresionesMf { get; set; }
        public string GenIngresoPaciente { get; set; }
        public string GenBanCerrar { get; set; }
        public string GenEsTarjetaD { get; set; }
        public string GenEsPromocionalPvp { get; set; }
    }
}
