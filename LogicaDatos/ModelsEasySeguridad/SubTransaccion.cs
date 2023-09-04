using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class SubTransaccion
    {
        public SubTransaccion()
        {
            AtribucionesSubtransaccion = new HashSet<AtribucionesSubtransaccion>();
        }

        public int IdSubtransaccion { get; set; }
        public int IdTransaccion { get; set; }
        public string Subtransaccion1 { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<AtribucionesSubtransaccion> AtribucionesSubtransaccion { get; set; }
    }
}
