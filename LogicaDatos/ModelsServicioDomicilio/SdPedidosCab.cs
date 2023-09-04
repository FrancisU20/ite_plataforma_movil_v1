using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdPedidosCab
    {
        public SdPedidosCab()
        {
            SdPedidosDet = new HashSet<SdPedidosDet>();
            SdTrackingVerificacionPedidos = new HashSet<SdTrackingVerificacionPedidos>();
        }

        public long PcaCodigo { get; set; }
        public string PcaCliente { get; set; }
        public string PcaTipoIdCliente { get; set; }
        public int EspCodigo { get; set; }
        public string PcaFormaPago { get; set; }
        public string PcaDireccionEntrega { get; set; }
        public DateTime PcaFechaRecepcion { get; set; }
        public DateTime PcaFechaFarmacia { get; set; }
        public DateTime PcaFechaFacturado { get; set; }
        public DateTime PcaFechaEntrega { get; set; }
        public string PcaObservacion { get; set; }
        public double PcaSubtotal { get; set; }
        public double PcaSubtotalIva { get; set; }
        public double PcaTotal { get; set; }
        public string PcaOficina { get; set; }
        public string PcaListaPrecios { get; set; }
        public string PcaUsuarioPedido { get; set; }
        public string PcaZona { get; set; }
        public string PcaExisteMf { get; set; }
        public string PcaEnFarmacia { get; set; }
        public string PcaSerieFactura { get; set; }
        public double PcaDescuentoPromocion { get; set; }
        public string PcaAplicaPromocion { get; set; }
        public string PcaEsReasignacion { get; set; }
        public string PcaRazonSocial { get; set; }
        public string PcaTelefono { get; set; }
        public string PcaCreditoFarmaenlace { get; set; }
        public string PcaUsuario { get; set; }
        public string PcaObservacionVoucher { get; set; }
        public string PcaRespuestaVoucher { get; set; }

        public virtual SdParEstadoPedido EspCodigoNavigation { get; set; }
        public virtual ICollection<SdPedidosDet> SdPedidosDet { get; set; }
        public virtual ICollection<SdTrackingVerificacionPedidos> SdTrackingVerificacionPedidos { get; set; }
    }
}
