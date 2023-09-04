using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class FlujoClaves
    {
        public FlujoClaves()
        {
            FlujoClavesDetalle = new HashSet<FlujoClavesDetalle>();
        }

        public int NumeroDocumento { get; set; }
        public string Usuario { get; set; }
        public string Estado { get; set; }
        public string Proceso { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoMakeChecher { get; set; }
        public string EstadoImpresion { get; set; }
        public string NumeroPreImpreso { get; set; }

        public virtual ICollection<FlujoClavesDetalle> FlujoClavesDetalle { get; set; }
    }
}
