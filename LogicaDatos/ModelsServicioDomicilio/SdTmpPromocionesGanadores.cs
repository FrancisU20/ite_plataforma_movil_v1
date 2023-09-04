using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesGanadores
    {
        public long PgaIdPromocion { get; set; }
        public string PgaCompania { get; set; }
        public string PgaSucursal { get; set; }
        public string PgaOficina { get; set; }
        public string PgaIdCliente { get; set; }
        public string PgaSerieFactura { get; set; }
        public string PgaCodigoPremio { get; set; }
        public decimal? PgaCantidad { get; set; }
        public int? PgaValorPos { get; set; }
        public DateTime? PgaFechaFactura { get; set; }
        public string PgaEstado { get; set; }
        public string PgaUsuario { get; set; }
        public string PgaTipoArticulo { get; set; }
        public string PcaEnvioPos { get; set; }
    }
}
