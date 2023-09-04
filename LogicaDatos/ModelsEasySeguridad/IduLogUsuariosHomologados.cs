using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class IduLogUsuariosHomologados
    {
        public int LogCodigo { get; set; }
        public string LogUsuarioHomologado { get; set; }
        public string LogUsuarioHomologa { get; set; }
        public DateTime LogFechaHomologa { get; set; }
        public string LogEstadoEasy { get; set; }
        public short? LogNroUsuariosHabilitados { get; set; }
        public short? LogNroUsuariosDeshabilitados { get; set; }
    }
}
