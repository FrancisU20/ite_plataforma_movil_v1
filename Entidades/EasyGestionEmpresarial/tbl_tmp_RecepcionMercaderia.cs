using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_tmp_RecepcionMercaderia
    {
        public string rm_identificador { get; set; }
        public string rm_usuario_farmacia { get; set; }
        public string rm_estado { get; set; }
        public string rm_data { get; set; }
        public string rm_data2 { get; set; }
        public DateTime rm_fecha_bodega { get; set; }
        public DateTime rm_fecha_registro { get; set; }
    }
}
