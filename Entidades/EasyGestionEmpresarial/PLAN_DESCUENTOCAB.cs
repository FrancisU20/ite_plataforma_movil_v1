using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_DESCUENTOCAB
    {
        public PLAN_DESCUENTOCAB()
        {
            this.PLAN_DESCUENTODET = new List<PLAN_DESCUENTODET>();
        }

        public long ID_PLAN { get; set; }
        public string SUCURSAL { get; set; }
        public string OFICINA { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string HORA { get; set; }
        public string USUARIO { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO { get; set; }
        public string ESTADO { get; set; }
        public decimal TOTALDSC { get; set; }
        public string TIPO { get; set; }
        public string ENVIO_POS { get; set; }
        public string IDBODEGA { get; set; }
        public string APLICACION { get; set; }
        public virtual ICollection<PLAN_DESCUENTODET> PLAN_DESCUENTODET { get; set; }
    }
}
