using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesPinesGanados
    {
        public string PpgSerieFactura { get; set; }
        public long PpgIdPromocion { get; set; }
        public string PpgNumeroPin { get; set; }
        public string PpgSucursal { get; set; }
        public string PpgOficina { get; set; }
        public string PpgIdCliente { get; set; }
        public string PpgCodigoArticulo { get; set; }
        public string PpgTipoArticulo { get; set; }
        public string EnvioPos { get; set; }
        public long PcaCodigo { get; set; }
    }
}
