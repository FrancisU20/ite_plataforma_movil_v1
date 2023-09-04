using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesDescuentoPromocional
    {
        public int? Idpromociones { get; set; }
        public string PdpSucursal { get; set; }
        public string PdpOficina { get; set; }
        public string PdpTipoDocumento { get; set; }
        public string PdpSerieFactura { get; set; }
        public string PdpCodigoProducto { get; set; }
        public DateTime? PdpFechaFactura { get; set; }
        public string PdpNumeroIdCliente { get; set; }
        public int? PdpCantidadVendida { get; set; }
        public decimal? PdpPvp { get; set; }
        public decimal? PdpPvf { get; set; }
        public decimal? PdpValorDescuento { get; set; }
        public decimal? PdpPorcentajeDescuento { get; set; }
        public string PdpEstado { get; set; }
        public int? PdpValorPos { get; set; }
        public decimal? PdpValorAsume { get; set; }
        public string PdpAsumeTotal { get; set; }
        public string PdpNumeroIdProveedor { get; set; }
        public string PdpUsuarioCreacion { get; set; }
        public DateTime? PdpFechaCreacion { get; set; }
        public string PdpUsuarioModifica { get; set; }
        public DateTime? PdpFechaModifica { get; set; }
        public string EnvioPos { get; set; }
        public string PdpAsumeFarmaenlace { get; set; }
        public string PdpAsumeLab { get; set; }
        public long PcaCodigo { get; set; }
    }
}
