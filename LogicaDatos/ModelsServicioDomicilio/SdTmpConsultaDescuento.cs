using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpConsultaDescuento
    {
        public int PcaCodigo { get; set; }
        public int? ConIdClientesCupo { get; set; }
        public string ConCompania { get; set; }
        public int? ConIdCliente { get; set; }
        public decimal? ConMontoAutorizado { get; set; }
        public decimal? ConMontoSobregiro { get; set; }
        public decimal? ConMontoUtilizado { get; set; }
        public DateTime? ConFechaActualizacion { get; set; }
        public DateTime? ConFechaVencimiento { get; set; }
        public decimal? ConMontoAutorizadoR { get; set; }
        public decimal? ConMontoUtilizadoR { get; set; }
        public decimal? ConMontoAutorizadoE { get; set; }
        public decimal? ConMontoUtilizadoE { get; set; }
        public string ConCctPorcentaje { get; set; }
    }
}
