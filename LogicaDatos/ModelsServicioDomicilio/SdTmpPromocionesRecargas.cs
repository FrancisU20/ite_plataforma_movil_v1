using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesRecargas
    {
        public long RecgIdPromociones { get; set; }
        public string RecgSucursal { get; set; }
        public string RecgOficina { get; set; }
        public string RecgSerieFactura { get; set; }
        public string RecgCodigoRecarga { get; set; }
        public long? RecgSecuencial { get; set; }
        public string RecgIdCliente { get; set; }
        public string RecgNumeroCelular { get; set; }
        public int? RecgCantidadRecarga { get; set; }
        public int? RecgValorRecarga { get; set; }
        public int? RecgNumeroCaja { get; set; }
        public string RecgOperadora { get; set; }
        public string RecgUsuario { get; set; }
        public string RecgEstado { get; set; }
        public string RecgOrigenRecarga { get; set; }
        public string EnvioPos { get; set; }
        public long PcaCodigo { get; set; }
    }
}
