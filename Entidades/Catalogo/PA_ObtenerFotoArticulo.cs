using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades.Catalogo
{
    public partial class PA_ObtenerFotoArticulo
    {
        [Key]
        public int fot_id_foto { get; set; }
        public string gru_codigo { get; set; }
        public Byte[] fot_grande_foto { get; set; }

    }
}
