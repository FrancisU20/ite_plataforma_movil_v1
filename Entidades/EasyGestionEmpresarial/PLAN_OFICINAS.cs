using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_OFICINAS
    {
        public long ID_PLAN { get; set; }
        public string SUCURSAL { get; set; }
        public string OFICINA { get; set; }
        public string OFICINA_CREACION { get; set; }
        public string IDBODEGA { get; set; }
        public string SUCURSAL_CREACION { get; set; }
        public string IDBODEGA_CREACION { get; set; }
        public string ORIGEN { get; set; }
        public virtual PLAN_INVENTARIO PLAN_INVENTARIO { get; set; }
    }
}
