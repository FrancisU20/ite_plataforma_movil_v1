using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class TblCopagoDescuentoConvenio
    {
        public string CdcSucursal { get; set; }
        public string CdcOficina { get; set; }
        public string CdcSerieFactura { get; set; }
        public string CdcCliente { get; set; }
        public string CdcContratoHumana { get; set; }
        public string CdcCodigoArticulo { get; set; }
        public decimal? CdcCopago { get; set; }
        public decimal? CdcDescuento { get; set; }
        public decimal? CdcValorCopago { get; set; }
        public decimal? CdcValorDescuento { get; set; }
        public decimal? CdcValorAplicadoDescuento { get; set; }
        public DateTime? CdcFechaRegistro { get; set; }
        public string CdcComentario { get; set; }
        public string EnvioPos { get; set; }
        public string CdcPaciente { get; set; }
        public string CdcNumeroTransito { get; set; }
        public string CdcNombrePaciente { get; set; }
    }
}
