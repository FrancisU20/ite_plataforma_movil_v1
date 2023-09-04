using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class tbl_articulos_codigosbarra
    {
        public string Compania { get; set; }
        public string codigo { get; set; }
        [Key]
        public string codigo_barra { get; set; }
        public string estado { get; set; }
        public string es_principal { get; set; }
        public string es_caja { get; set; }
        public string ENVIO_POS { get; set; }
    }
}
