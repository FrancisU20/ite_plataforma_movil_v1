using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class PA_GEN_GenerarKardexMatriz
    {
        [Key, Column(Order = 0)]
        public string result { get; set; }
    }
}
