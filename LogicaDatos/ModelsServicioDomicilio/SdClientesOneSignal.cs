using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdClientesOneSignal
    {
        public int OsCodigo { get; set; }
        public int MotCodigo { get; set; }
        public string OsIdOnesignal { get; set; }
        public string OsUsuarioRegistro { get; set; }
        public DateTime? OsFechaRegistro { get; set; }
    }
}
