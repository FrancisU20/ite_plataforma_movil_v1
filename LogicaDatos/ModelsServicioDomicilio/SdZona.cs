using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdZona
    {
        public SdZona()
        {
            SdRelFarmaciaZona = new HashSet<SdRelFarmaciaZona>();
            SdRelMotorizadoZona = new HashSet<SdRelMotorizadoZona>();
            SdZonaAdministradores = new HashSet<SdZonaAdministradores>();
        }

        public string ZonCodigo { get; set; }
        public string ZonProvincia { get; set; }
        public string ZonNombre { get; set; }
        public string ZonObservacion { get; set; }
        public string ZonProvinciaNombre { get; set; }
        public string ZonEstado { get; set; }

        public virtual ICollection<SdRelFarmaciaZona> SdRelFarmaciaZona { get; set; }
        public virtual ICollection<SdRelMotorizadoZona> SdRelMotorizadoZona { get; set; }
        public virtual ICollection<SdZonaAdministradores> SdZonaAdministradores { get; set; }
    }
}
