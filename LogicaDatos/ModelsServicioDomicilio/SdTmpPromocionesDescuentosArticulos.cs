using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesDescuentosArticulos
    {
        public long PdaIdPromociones { get; set; }
        public string PdaCodigo { get; set; }
        public string PdaSerieFactura { get; set; }
        public string PdaOficina { get; set; }
        public string PdaSucursal { get; set; }
        public string PdaNumeroIdcliente { get; set; }
        public int? PdaCantidad { get; set; }
        public decimal? PdaValorDescuento { get; set; }
        public decimal? PdaPorcentajeDescuento { get; set; }
        public decimal? PdaValorExtra { get; set; }
        public string PdaEnvioPos { get; set; }
    }
}
