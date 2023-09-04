using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFpcheque
    {
        public string CheValor { get; set; }
        public string CheNroCheque { get; set; }
        public string CheIdBanco { get; set; }
        public string CheBanco { get; set; }
        public string CheCuenta { get; set; }
        public string CheTelefono { get; set; }
        public string CheAutorizacion { get; set; }
        public string CheTipoDoc { get; set; }
        public string CheNumeroDoc { get; set; }
        public string CheAnio { get; set; }
        public string CheSexo { get; set; }
        public long PcaCodigo { get; set; }
    }
}
