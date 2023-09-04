using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class MotorizadoPedidoViewModel
    {
        public long PcaCodigo { get; set; }
        public string PcaDireccionEntrega { get; set; }
        public string NombreCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string PcaFechaRecepcion { get; set; }
        public string PcaFechaFacturado { get; set; }
        public string PcaFechaFarmacia { get; set; }
        public string PcaFechaEntrega { get; set; }
        public string PcaTelefono { get; set; }
        public string ZfaOficinaNombre { get; set; }
        public string ZfaOficina { get; set; }
        public string EspEstado { get; set; }
        public string EspNombre { get; set; }
        public int MotCodigo { get; set; }
        public string PcaSerieFactura { get; set; }
        public int TotalTransferencias { get; set; }
        public string FechaSistema { get; set; } = "";
        public string Observacion { get; set; } = "";
        public string ObservacionVoucher { get; set; } = "";


    }
}
