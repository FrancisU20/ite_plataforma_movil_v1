using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFacturasCupoEfectivo
    {
        public long PcaCodigo { get; set; }
        public int? FceIdRegistro { get; set; }
        public string FceOficina { get; set; }
        public string FceNumeroFactura { get; set; }
        public string FceTipoIdcliente { get; set; }
        public string FceNumeroIdcliente { get; set; }
        public DateTime? FceFechaIngreso { get; set; }
        public decimal? FceValorCupo { get; set; }
        public decimal? FceDescuentoAplicado { get; set; }
        public string FceEstado { get; set; }
        public string FceUsuario { get; set; }
        public string EnvioPos { get; set; }
    }
}
