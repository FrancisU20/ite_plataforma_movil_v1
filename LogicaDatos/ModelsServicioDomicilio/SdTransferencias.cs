using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTransferencias
    {
        public int TranCodigo { get; set; }
        public string TranOficinaOrigen { get; set; }
        public string TranOficinaDestino { get; set; }
        public string TranIpServidorDestino { get; set; }
        public string TranIpServidorOrigen { get; set; }
        public string TranIpCajaDestino { get; set; }
        public string TranIpUsuarioDestino { get; set; }
        public int PcaCodigo { get; set; }
        public string TranEstado { get; set; }
        public string TranComprobante { get; set; }
        public string TranFechaCreacion { get; set; }
        public string TranUsuarioOrigen { get; set; }
        public string TranEstadoPedido { get; set; }
    }
}
