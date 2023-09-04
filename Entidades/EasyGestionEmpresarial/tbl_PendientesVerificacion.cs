using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_PendientesVerificacion
    {
        public int pe_numero { get; set; }
        public int pe_traspaso { get; set; }
        public string pe_estado { get; set; }
        public string pe_tipo_mov { get; set; }
        public string pe_cajas { get; set; }
        public string pe_fundas { get; set; }
        public string pe_pacas { get; set; }
        public string pe_usuario_registro { get; set; }
        public Nullable<System.DateTime> pe_fecha_registro { get; set; }
    }
}
