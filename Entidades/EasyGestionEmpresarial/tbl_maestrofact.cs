using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_maestrofact
    {
        public tbl_maestrofact()
        {
            this.tbl_detallefact = new List<tbl_detallefact>();
        }

        public string Compania { get; set; }
        public string Sucursal { get; set; }
        public string Oficina { get; set; }
        public string tipo_documento { get; set; }
        public int numero_factura { get; set; }
        public string tipo_idcliente { get; set; }
        public string numero_idcliente { get; set; }
        public Nullable<System.DateTime> fecha_factura { get; set; }
        public Nullable<double> subtotal { get; set; }
        public Nullable<double> iva { get; set; }
        public Nullable<double> descuento { get; set; }
        public Nullable<double> totalfactura { get; set; }
        public string moneda { get; set; }
        public Nullable<short> formapago { get; set; }
        public string estatus { get; set; }
        public Nullable<short> direccion { get; set; }
        public Nullable<double> saldofactura { get; set; }
        public string codigo_vendedor { get; set; }
        public Nullable<double> comision_ventas { get; set; }
        public string codigo_entrega { get; set; }
        public Nullable<double> retencion { get; set; }
        public Nullable<double> tipo_cambio { get; set; }
        public string impreso { get; set; }
        public Nullable<int> numero_devolucion { get; set; }
        public Nullable<short> tipo_devolucion { get; set; }
        public Nullable<short> motivo_devolucion { get; set; }
        public Nullable<double> subtotal_noiva { get; set; }
        public Nullable<short> plazo { get; set; }
        public Nullable<int> numero_nota { get; set; }
        public string tipo_docdevolucion { get; set; }
        public string lista_precios { get; set; }
        public Nullable<double> subtotalventa { get; set; }
        public string contabilizado { get; set; }
        public Nullable<System.DateTime> fechacontabilizacion { get; set; }
        public string tipocomprobante { get; set; }
        public Nullable<int> numerocomprobante { get; set; }
        public string idbodega { get; set; }
        public Nullable<int> numeropedido { get; set; }
        public Nullable<short> EstacionId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<int> NumeroGuiaRemision { get; set; }
        public string comentario { get; set; }
        public Nullable<double> flete { get; set; }
        public string estatuspago { get; set; }
        public string NombreTransporte { get; set; }
        public Nullable<double> NumeroBultos { get; set; }
        public string UnidadMedidaBultos { get; set; }
        public string tipopedido { get; set; }
        public Nullable<int> IdTaxGroup { get; set; }
        public string CentroCosto { get; set; }
        public Nullable<double> subtotalIce { get; set; }
        public Nullable<double> link { get; set; }
        public Nullable<int> numeroOrdenInst { get; set; }
        public string Serie_Factura { get; set; }
        public string Numero_Aut_Factura { get; set; }
        public string Caducidad_Aut_Factura { get; set; }
        public float Descuento_Factura { get; set; }
        public float ValorIva { get; set; }
        public string Observacion { get; set; }
        public string generado_VTC { get; set; }
        public Nullable<int> id_generado_VTC { get; set; }
        public Nullable<System.DateTime> fechaHora_factura { get; set; }
        public string ENVIO_POS { get; set; }
        public string direccion_matriz { get; set; }
        public string telefono_matriz { get; set; }
        public string contribuyente_especial { get; set; }
        public string razon_social { get; set; }
        public virtual ICollection<tbl_detallefact> tbl_detallefact { get; set; }
    }
}
