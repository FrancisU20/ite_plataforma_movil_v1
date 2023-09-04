using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PA_Planificaciones
    {
        public long id_plan { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public string reconteo { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
    }
}
