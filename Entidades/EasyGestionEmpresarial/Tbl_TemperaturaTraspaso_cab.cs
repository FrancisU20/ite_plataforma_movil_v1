using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class Tbl_TemperaturaTraspaso_cab
    {
        public string ttc_tr_fol { get; set; }
        public string ttc_contenedor { get; set; }
        public decimal ttc_temperatura { get; set; }
        public string ttc_observacion { get; set; }
        public DateTime ttc_fecha { get; set; }
        public string ttc_usuario { get; set; }
        public string ENVIO_POS { get; set; }
    }
}
