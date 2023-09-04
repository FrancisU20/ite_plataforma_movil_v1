using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdPedidoTarjetas
    {
        public long PcaCodigo { get; set; }
        public string PetProducto { get; set; }
        public string PetTipo { get; set; }
        public string PetNumeroTarjeta { get; set; }

        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
    }
}
