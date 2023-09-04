using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_ImpresionEtiquetas
    {
        public int id_impresion_etiqueta { get; set; }
        public string codigo_articulo { get; set; }
        public string codigo_barras { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public string estado { get; set; }
        public DateTime fecha_registro { get; set; }
        public string usuario_registro { get; set; }
    }
}
