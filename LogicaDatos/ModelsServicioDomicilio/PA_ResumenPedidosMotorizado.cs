using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class PA_ResumenPedidosMotorizado
    {
        public long PcaCodigo { get; set; }
        public string PcaDireccionEntrega { get; set; }
        public DateTime PcaFechaRecepcion { get; set; }
        public DateTime PcaFechaFacturado { get; set; }
        public DateTime PcaFechaFarmacia { get; set; }
        public DateTime PcaFechaEntrega { get; set; }
        public string PcaTelefono { get; set; }
        public string ZfaOficinaNombre { get; set; }
        public string ZfaOficina { get; set; }
        public string EspEstado { get; set; }
        public string EspNombre { get; set; }
        public int MotCodigo { get; set; }
        public string PcaSerieFactura { get; set; }
        public string PcaObservacion { get; set; }
        public string PcaObservacionVoucher { get; set; }
    }
}
