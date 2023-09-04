using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdRelClienteEntrega
    {
        public string CenNumeroIdCliente { get; set; }
        public string CenProvincia { get; set; }
        public string CenZona { get; set; }
        public string CenDireccion { get; set; }
        public DateTime CenFechaRegistro { get; set; }
        public string CenProvinciaNombre { get; set; }
        public string CenZonaNombre { get; set; }
    }
}
