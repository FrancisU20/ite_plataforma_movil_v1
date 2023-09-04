using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Inconsistencias
{
    public partial class tbl_motivo
    {
        public int id_motivo { get; set; }
        public string motivo { get; set; }
        public Nullable<int> id_validacion { get; set; }
    }
}
