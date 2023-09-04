using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PA_ConsultarArtituloInventarioTotal
    {
        public string codigo_barra { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int valor_POS { get; set; }
        public double existencias { get; set; }
        public string laboratorio { get; set; }
    }
}
