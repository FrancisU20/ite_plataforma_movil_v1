using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTrackingMotorizadoPedidos
    {
        public SdTrackingMotorizadoPedidos()
        {
            SdTrackingVerificacionPedidos = new HashSet<SdTrackingVerificacionPedidos>();
        }

        public int TrkCodigo { get; set; }
        public int? MotCodigo { get; set; }
        public DateTime? TrkFechaRegistro { get; set; }
        public string TrkUsuarioRegistro { get; set; }
        public string TrkEstadoTraking { get; set; }
        public double? TrkLatitud { get; set; }
        public double? TrkLongitud { get; set; }
        public string TrkSignalrEnviado { get; set; }
        public string TrkSignalrObservacion { get; set; }

        public virtual ICollection<SdTrackingVerificacionPedidos> SdTrackingVerificacionPedidos { get; set; }
    }
}
