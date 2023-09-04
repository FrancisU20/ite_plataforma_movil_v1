using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class Tbl_DetalleTransferenciaBC
    {
        public int dtbc_num_pedido { get; set; }
        public string dtbc_sucursal { get; set; }
        public string dtbc_oficina { get; set; }
        public string dtbc_tipo_mov { get; set; }
        public int dtbc_tr_fol { get; set; }
        public string envio_pos { get; set; }

    }
}
