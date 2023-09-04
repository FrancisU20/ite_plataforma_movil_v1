using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_RegistroAppMovil
    {
        public string tipo_movimiento { get; set; }
        public Int64 numero_movimiento { get; set; }
        public DateTime fecha_registro { get; set; }
        public string usuario_registro { get; set; }
        public string tipo_inventario { get; set; }
        public string num_documento { get; set; }

    }
}
