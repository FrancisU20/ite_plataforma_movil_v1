using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_tablas
    {
        /*
         oficina	nombre	correo_electronico	srvr_ip
         */
        public string id_tabla { get; set; }
        public string cx_argumento { get; set; }
        public string tx_descripcion { get; set; }
        //public string srvr_ip { get; set; }
        public string envio_pos { get; set; }
    }
}
