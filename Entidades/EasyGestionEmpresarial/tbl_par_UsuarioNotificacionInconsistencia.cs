using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_par_UsuarioNotificacionInconsistencia
    {
        public string usuario { get; set; }
        public string correo { get; set; }
        public string aplicacion { get; set; }
        public string estado { get; set; }
    }
}
