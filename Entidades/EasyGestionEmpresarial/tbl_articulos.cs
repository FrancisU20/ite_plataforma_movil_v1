using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class tbl_articulos
    {
        public string Compania { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string es_psicotropico { get; set; }
        public string marca { get; set; }
        public string linea { get; set; }
        public string clase { get; set; }
        public string RESTRINGIDO_VENTA { get; set; }
        public string RESTRINGIDO_INVENTARIO { get; set; }
        public string RESTRINGIDO_DSCTOS { get; set; }
        public decimal PVF { get; set; }
        public int valor_POS { get; set; }
        public string art_autoservicio { get; set; }
        public string status { get; set; }
    }
}
