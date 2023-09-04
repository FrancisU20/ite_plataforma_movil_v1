using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class TblUsuariosAcceso
    {
        public string UsuUsuario { get; set; }
        public string UsuPassword { get; set; }
        public string UsuEstado { get; set; }
        public DateTime? UsuFechaCreacion { get; set; }
    }
}
