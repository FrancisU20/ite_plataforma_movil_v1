using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class tbl_TemperaturaTraspaso_det
    {
        public string ttd_tr_fol { get; set; }
        public string ttd_producto { get; set; }
        public string ttd_contenedor { get; set; }
        public decimal ttd_temperatura { get; set; }
        public string ttd_observacion { get; set; }
        public DateTime ttd_fecha { get; set; }
        public string ttd_usuario { get; set; }
        public string ENVIO_POS { get; set; }
    }
}
