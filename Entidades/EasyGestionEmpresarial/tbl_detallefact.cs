using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_detallefact
    {
        public string Compania { get; set; }
        public string Sucursal { get; set; }
        public string Oficina { get; set; }
        public string tipo_documento { get; set; }
        public int numero_factura { get; set; }
        public string codigo_producto { get; set; }
        public int secuencial { get; set; }
        public Nullable<float> cantidad { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<double> descuento { get; set; }
        public Nullable<double> precio_total { get; set; }
        public string codigo_motivo { get; set; }
        public Nullable<float> cantidad_devuelta { get; set; }
        public Nullable<float> cantidad_entregada { get; set; }
        public Nullable<short> excento_iva { get; set; }
        public Nullable<double> costo { get; set; }
        public string tipoproducto { get; set; }
        public Nullable<float> comision { get; set; }
        public Nullable<int> IdTaxGroup { get; set; }
        public string tipolinea { get; set; }
        public string comentario { get; set; }
        public string Descripcion { get; set; }
        public Nullable<double> valor_ice { get; set; }
        public double valor_iva { get; set; }
        public string tipo { get; set; }
        public string Rangos_Referencia { get; set; }
        public string Serie_Factura { get; set; }
        public double Total_Ice_Item { get; set; }
        public double Total_Iva_Item { get; set; }
        public string Observacion_det { get; set; }
        public double Descuento_Factura { get; set; }
        public virtual tbl_maestrofact tbl_maestrofact { get; set; }
    }
}
