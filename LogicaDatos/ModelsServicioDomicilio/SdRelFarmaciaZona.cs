using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdRelFarmaciaZona
    {
        public int ZfaCodigo { get; set; }
        public string ZonCodigo { get; set; }
        public string ZonProvincia { get; set; }
        public string ZfaOficina { get; set; }
        public string ZfaOficinaNombre { get; set; }
        public string ZfaSucursal { get; set; }
        public string ZfaEstado { get; set; }
        public string ZfaIp { get; set; }

        public virtual SdZona Zon { get; set; }
    }
}
