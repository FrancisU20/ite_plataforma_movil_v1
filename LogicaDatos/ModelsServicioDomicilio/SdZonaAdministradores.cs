using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdZonaAdministradores
    {
        public string ZonCodigo { get; set; }
        public string ZonProvincia { get; set; }
        public string ZadCedula { get; set; }
        public string ZadNombres { get; set; }
        public string ZadNombreCorto { get; set; }
        public string ZadEstado { get; set; }

        public virtual SdZona Zon { get; set; }
    }
}
