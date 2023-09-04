using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class GPSMotorizadoViewModel
    {
        public int MotCodigo { get; set; }
        public string AccionRegistro { get; set; }
        public double TrkLatitud { get; set; }
        public double TrkLongitud { get; set; }
        public List<PedidoViewModel> Pedidos { get; set; }
    }
}
