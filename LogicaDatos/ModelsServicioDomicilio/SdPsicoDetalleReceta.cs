using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdPsicoDetalleReceta
    {
        public string PdrSerieReceta { get; set; }
        public string PdrItem { get; set; }
        public string PdrCodigo { get; set; }
        public string PdrDescripcion { get; set; }
        public int PdrEnterosReceta { get; set; }
        public int PdrFraccionReceta { get; set; }
        public int PdrEnteroFactura { get; set; }
        public int PdrFraccionFactura { get; set; }
        public int PdrEnteroSaldo { get; set; }
        public int PdrFraccionSaldo { get; set; }
        public string PdrUnidadPos { get; set; }
        public string PdrValorPos { get; set; }
        public string PdrEnvioPos { get; set; }
        public string PdrNumeroIdCliente { get; set; }
        public string PdrSerieFactura { get; set; }
    }
}
