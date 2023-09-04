

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class VIRT_TRASPASOVERIFMERCADERIA
    {
        public string numTraspaso { get; set; }
        public string tipoMovimiento { get; set; }
        public string procesado { get; set; }
        public string pendiente { get; set; }
        public string estado { get; set; }
        public string usuario { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string vtvm_estado_traspaso { get; set; }
        public string vtvm_estado_recepcion { get; set; }
        public string vtvm_ip_maquina { get; set; }
        public string vtvm_usuario_recepcion { get; set; }
        public int tr_fol { get; set; }
    }
}
