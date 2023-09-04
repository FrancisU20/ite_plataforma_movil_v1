using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_LoginUsuario
    {
        public string lg_cookie { get; set; }
        public string lg_compania { get; set; }
        public string lg_oficina { get; set; }
        public string lg_sucursal { get; set; }
        public string lg_nombreUsuario { get; set; }
        public string lg_estado { get; set; }
        public string lg_ipCaja { get; set; }
        public Nullable<System.DateTime> lg_fecha { get; set; }
    }
}
