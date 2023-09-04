using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_USUARIO
    {
        public long ID_PLAN { get; set; }
        public string ORIGEN { get; set; }
        public string usuario { get; set; }
        public string estado { get; set; }
    }
}
