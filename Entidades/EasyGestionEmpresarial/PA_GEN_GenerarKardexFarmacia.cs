using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class PA_GEN_GenerarKardexFarmacia
    {
        [Key, Column(Order = 0)]
        public string result { get; set; }
        [Key, Column(Order = 1)]
        public string nummov { get; set; }
    }
}
