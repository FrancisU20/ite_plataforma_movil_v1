using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_INVENTARIO
    {
        public PLAN_INVENTARIO()
        {
            this.PLAN_ARTICULOS = new List<PLAN_ARTICULOS>();
            this.PLAN_OFICINAS = new List<PLAN_OFICINAS>();
        }

        public long ID_PLAN { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public string USUARIO { get; set; }
        public string SOLICITANTE { get; set; }
        public string ESTADO { get; set; }
        public Nullable<int> NOCONTEO { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICA { get; set; }
        public string TIPO { get; set; }
        public string DESCONTABLE { get; set; }
        public System.DateTime FECHA_IMPRESO { get; set; }
        public string USUARIO_IMPRESO { get; set; }
        public System.DateTime FECHA_RECONTEO { get; set; }
        public string USUARIO_RECONTEO { get; set; }
        public System.DateTime FECHA_DESCUENTO { get; set; }
        public string USUARIO_DESCUENTO { get; set; }
        public System.DateTime FECHA_FINALIZADO { get; set; }
        public string USUARIO_FINALIZADO { get; set; }
        public string OFICINA { get; set; }
        public string ENVIO_POS { get; set; }
        public string SUCURSAL { get; set; }
        public string IDBODEGA { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string PROCESO { get; set; }
        public string ORIGEN { get; set; }
        public virtual ICollection<PLAN_ARTICULOS> PLAN_ARTICULOS { get; set; }
        public virtual PLAN_FACTURACION PLAN_FACTURACION { get; set; }
        public virtual ICollection<PLAN_OFICINAS> PLAN_OFICINAS { get; set; }
    }
}
