using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class FlujoClavesHistorico
    {
        public int NumeroDocumento { get; set; }
        public string NumeroPreImpresoAnterior { get; set; }
        public string NumeroPreImpreso { get; set; }
        public DateTime FechaHora { get; set; }
        public string Usuario { get; set; }
    }
}
