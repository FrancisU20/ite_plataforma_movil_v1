using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class Sesiones
    {
        public string IdSesion { get; set; }
        public string NombreCorto { get; set; }
        public string Ip { get; set; }
        public byte Conexiones { get; set; }
        public DateTime Fechahora { get; set; }
    }
}
