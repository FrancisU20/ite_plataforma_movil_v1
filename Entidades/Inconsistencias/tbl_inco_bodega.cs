using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Inconsistencias
{
    public partial class tbl_inco_bodega
    {
        public tbl_inco_bodega()
        {
            this.tbl_detalle_inco_bodega = new List<tbl_detalle_inco_bodega>();
        }

        public long id_inco_bodega { get; set; }
        public string sec_inco_bodega { get; set; }
        public string alias { get; set; }
        public string id_farmacia { get; set; }
        public string ci_empleado { get; set; }
        public string empleado { get; set; }
        public string certificador { get; set; }
        public long num_traspaso { get; set; }
        public long num_ei { get; set; }
        public Nullable<System.DateTime> fecha_reporte { get; set; }
        public Nullable<System.DateTime> fecha_proceso { get; set; }
        public Nullable<System.DateTime> fecha_cierre { get; set; }
        public string estado { get; set; }
        public string tras_certificado { get; set; }
        public string mail_fallido_farmacia { get; set; }
        public string mail_fallido_matriz { get; set; }
        public Nullable<System.DateTime> fecha_traspaso { get; set; }
        public virtual ICollection<tbl_detalle_inco_bodega> tbl_detalle_inco_bodega { get; set; }
    }
}
