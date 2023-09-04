using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PA_ArticulosPlanificacionResumen
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int cantidad { get; set; }
        public int conteo { get; set; }
        public int diferencia { get; set; }
        public int entero { get; set; }
        public int fraccion { get; set; }
        public Nullable<DateTime> fecha_finalizado { get; set; }
        public decimal valordiferencia { get; set; }
    }
}
