using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PV_TraspasoVerifMercaderia_Det
    {
        public string tvmd_numero_traspaso { get; set; }
        public string tvmd_tipo_mercaderia { get; set; }
        public Nullable<int> tvmd_numero_procesadas { get; set; }
        public Nullable<int> tvmd_numero_pendientes { get; set; }
        public string tvmd_usuario { get; set; }
    }
}
