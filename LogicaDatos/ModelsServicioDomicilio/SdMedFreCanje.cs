using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdMedFreCanje
    {
        public string CanArticulo { get; set; }
        public string CanIdCliente { get; set; }
        public long PcaCodigo { get; set; }
        public string CanNumFactura { get; set; }
        public int CanCantidadFactura { get; set; }
        public int CanCantidadPedido { get; set; }
        public string CanEstado { get; set; }
    }
}
