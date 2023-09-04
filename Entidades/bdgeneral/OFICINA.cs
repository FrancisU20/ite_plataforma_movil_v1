using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.bdgeneral
{
    public partial class OFICINA
    {
        public string CODIGO_OFICINA { get; set; }
        public string NOMBRE { get; set; }
        public string CODIGO_SUCURSAL { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string ENVIO_POS { get; set; }
    }
}
