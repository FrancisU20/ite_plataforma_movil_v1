using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFptarjetas
    {
        public long PcaCodigo { get; set; }
        public string TarValor { get; set; }
        public string TarAutorizacion { get; set; }
        public string TarBanco { get; set; }
        public string TarTarjeta { get; set; }
        public string TarTipoCredito { get; set; }
        public string TarPlazo { get; set; }
        public string TarNumero { get; set; }
        public string TarValidez { get; set; }
        public string TarTelefono { get; set; }
        public string TarBaseCero { get; set; }
        public string TarBaseDoce { get; set; }
        public string TarIva { get; set; }
        public string TarMinimoTarjeta { get; set; }
    }
}
