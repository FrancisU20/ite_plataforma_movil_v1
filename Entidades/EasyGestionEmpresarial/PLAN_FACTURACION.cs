using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_FACTURACION
    {
        public long ID_PLAN { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public string ESTADO { get; set; }
        public string OFICINA { get; set; }
        public string SUCURSAL { get; set; }
        public string IDBODEGA { get; set; }
        public string ORIGEN { get; set; }
        public virtual PLAN_INVENTARIO PLAN_INVENTARIO { get; set; }
    }
}
