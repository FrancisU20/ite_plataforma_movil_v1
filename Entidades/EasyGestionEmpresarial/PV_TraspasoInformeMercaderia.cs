using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PV_TraspasoInformeMercaderia
    {
        public int tim_id { get; set; }
        public string tim_codigo { get; set; }
        public Nullable<System.DateTime> tim_fecha { get; set; }
        public string tim_usuario { get; set; }
        public string tim_traspasos { get; set; }
    }
}
