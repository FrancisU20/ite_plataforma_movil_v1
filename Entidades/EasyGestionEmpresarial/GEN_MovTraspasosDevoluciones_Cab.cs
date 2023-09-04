using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class GEN_MovTraspasosDevoluciones_Cab
    {
        public Int64 mtc_codigo_movimiento { get; set; }
        public string mtc_oficina { get; set; }
        public string mtc_sucursal { get; set; }
        public string mtc_id_bodega { get; set; }
        public Int64 mtc_numero_tras_dev { get; set; }
        public string mtc_tipo_movimiento { get; set; }
        public DateTime mtc_fecha_movimiento { get; set; }
        public string mtc_estado { get; set; }
        public string mtc_oficina_origen { get; set; }
        public string mtc_usuario_modifica { get; set; }
    }
}
