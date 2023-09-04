using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class Oficinas
    {
        /*
         oficina	nombre	correo_electronico	srvr_ip
         */
        public string oficina { get; set; }
        public string nombre { get; set; }
        public string correo_electronico { get; set; }
        //public string srvr_ip { get; set; }
        public string compania { get; set; }
        public string sucursal { get; set; }
        public string es_autoservicio { get; set; }
    }
}
