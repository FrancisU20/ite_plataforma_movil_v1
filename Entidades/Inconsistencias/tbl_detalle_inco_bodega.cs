using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Inconsistencias
{
    public partial class tbl_detalle_inco_bodega
    {
        public long id_detalle_inco_bodega { get; set; }
        public long id_inco_bodega { get; set; }
        public int id_motivo { get; set; }
        public string id_producto { get; set; }
        public string otro { get; set; }
        public Nullable<int> cantidad { get; set; }
        public string solucion { get; set; }
        public string nota { get; set; }
        public string num_ing_egr { get; set; }
        public string aceptacion { get; set; }
        public string conformidad { get; set; }
        public string obs_inconformidad { get; set; }
        public virtual tbl_inco_bodega tbl_inco_bodega { get; set; }

    }
}
