using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesFavoritos
    {
        public string NombreCorto { get; set; }
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public bool Habilitado { get; set; }

        public virtual Usuarios NombreCortoNavigation { get; set; }
        public virtual Transacciones Transacciones { get; set; }
    }
}
