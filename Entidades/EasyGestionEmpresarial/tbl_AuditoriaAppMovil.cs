using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_AuditoriaAppMovil
    {
        public string aum_oficina { get; set; }
        public string aum_tipo_movimiento { get; set; }
        public int aum_numero_movimiento { get; set; }
        public DateTime aum_fecha_registro { get; set; }
        public string aum_usuario_registro { get; set; }
        public DateTime aum_fecha_ejecucion { get; set; }
    }
}
