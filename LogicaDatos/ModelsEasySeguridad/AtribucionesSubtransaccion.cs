using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesSubtransaccion
    {
        public string NombreCorto { get; set; }
        public int IdSubtransaccion { get; set; }
        public bool Habilitado { get; set; }

        public virtual SubTransaccion IdSubtransaccionNavigation { get; set; }
        public virtual Usuarios NombreCortoNavigation { get; set; }
    }
}
