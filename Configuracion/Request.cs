using Entidades.bdgeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion
{
    public class Request
    {
        public OFICINA_IP OFICINA_IP { get; set; }
        public List<OFICINA_IP> List_OFICINA_IP { get; set; }
    }
}
