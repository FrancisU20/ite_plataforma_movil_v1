using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class IduUsuariosNoNomina
    {
        public int UsuCodigo { get; set; }
        public string UsuCedula { get; set; }
        public string UsuNombres { get; set; }
        public string UsuApellidos { get; set; }
        public string UsuCentroCosto { get; set; }
        public bool UsuEstado { get; set; }
        public string UsuMotivo { get; set; }
        public DateTime? UsuFechaInactivo { get; set; }
        public string UsuNombreArchivo { get; set; }
        public string UsuMimeArchivo { get; set; }
        public string UsuTipo { get; set; }
        public string UsuUsuarioCrea { get; set; }
        public string UsuUsuarioActualiza { get; set; }
        public DateTime UsuFechaCreado { get; set; }
        public DateTime UsuFechaActualiza { get; set; }
    }
}
