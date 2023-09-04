using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdRelMotorizadoZona
    {
        public long MtzCodigo { get; set; }
        public int MotCodigo { get; set; }
        public string ZonCodigo { get; set; }
        public string ZonProvincia { get; set; }
        public DateTime? MtzFechaRegistro { get; set; }
        public string MtzDescripcion { get; set; }
        public string MtzEstado { get; set; }

        public virtual SdMotorizado MotCodigoNavigation { get; set; }
        public virtual SdZona Zon { get; set; }
    }
}
