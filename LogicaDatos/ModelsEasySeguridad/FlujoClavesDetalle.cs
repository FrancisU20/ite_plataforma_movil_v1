using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class FlujoClavesDetalle
    {
        public int NumeroDocumento { get; set; }
        public int SecuencialDetalle { get; set; }
        public string Estado { get; set; }
        public DateTime FechaDetalle { get; set; }
        public string Proceso { get; set; }
        public string Login { get; set; }
        public string NombreUsuario { get; set; }
        public string Identificacion { get; set; }
        public string NomGrupoFinanciero { get; set; }
        public string Usuario { get; set; }
        public string UsuarioCustodio { get; set; }
        public string EntregadoA { get; set; }

        public virtual FlujoClaves NumeroDocumentoNavigation { get; set; }
    }
}
