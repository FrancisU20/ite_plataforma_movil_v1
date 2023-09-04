using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class UsuariosLogon
    {
        public int IdLogon { get; set; }
        public string NombreCorto { get; set; }
        public string Aplicacion { get; set; }
        public string DireccionIp { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
    }
}
