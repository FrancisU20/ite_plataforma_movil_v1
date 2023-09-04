using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class tbl_ControlPlanificaciones
    {
        public long cp_id_plan { get; set; }
        public string cp_oficina { get; set; }
        public string cp_sucursal { get; set; }
        public string cp_id_bodega { get; set; }
        public string cp_origen { get; set; }
        public string cp_usuario_registro { get; set; }
        public Nullable<System.DateTime> cp_fecha_registro { get; set; }
        public string cp_ip_registro { get; set; }
        public string cp_estado { get; set; }
        public string cp_dispositivo { get; set; }
    }
}
