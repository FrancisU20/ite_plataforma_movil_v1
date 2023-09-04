using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.bdgeneral
{
    public partial class OFICINA_IP
    {
        public string oficina { get; set; }
        public string ip_red { get; set; }
        public Nullable<int> ip_rango_inicial { get; set; }
        public Nullable<int> ip_rango_final { get; set; }
        public string ENVIO_POS { get; set; }
    }
}
