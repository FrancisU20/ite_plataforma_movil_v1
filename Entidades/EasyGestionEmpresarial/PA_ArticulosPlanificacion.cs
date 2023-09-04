using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PA_ArticulosPlanificacion
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int valorconversion { get; set; }
        public Nullable<double> stock { get; set; }
        public string barra { get; set; }
        public string barra1 { get; set; }
        public string barras { get; set; }
        public string pvf { get; set; }
    }
}
