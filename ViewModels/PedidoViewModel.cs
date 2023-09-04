using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PedidoViewModel
    {
        public long PcaCodigo { get; set; }
        public string SerieFactura { get; set; }
        public string NumeroTransferencia { get; set; }
        public double TrkLatitud { get; set; }
        public double TrkLongitud { get; set; }
        public string FechaSistema { get; set; }
    }
}
